using CFBPoll.Utilities;
using CFBPollDTOs;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace CFBPoll.Data.Modules
{
    public class TextDataModule
    {
        private readonly NameCorrector _nameCorrector;
        private readonly string _mdPredictionsFilePath;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _teamsPath;
        private readonly string _txtPollFilePath;
        private readonly string _txtPredictionsFilePath;
        private readonly string _txtPredictionsResultsFilePath;

        public TextDataModule(IConfiguration config, NameCorrector nameCorrector)
        {
            _mdPredictionsFilePath = config.GetSection("AppSettings:PredictionsPath_md")?.Value ?? string.Empty;
            _nameCorrector = nameCorrector;
            _teamsPath = config.GetSection("AppSettings:TeamsPath")?.Value ?? string.Empty;
            _txtPollFilePath = config.GetSection("AppSettings:PollOutputPath_txt")?.Value ?? string.Empty;
            _txtPredictionsFilePath = config.GetSection("AppSettings:PollPredictionsPath_txt")?.Value ?? string.Empty;
            _txtPredictionsResultsFilePath = config.GetSection("AppSettings:PredictionsResultsPath_txt")?.Value ?? string.Empty;
        }

        #region public methods

        /// <summary>
        /// Gets predictions made previously from a file
        /// </summary>
        /// <param name="season">The season for the predictions</param>
        /// <param name="week">The week for the predictions</param>
        /// <returns>A list of Games containing the game information and the predicted betting lines</returns>
        public IEnumerable<Game> GetPredictions(int season, int? week)
        {
            var predictions = new List<Game>();

            //Get the predictions from the directory
            var predictionFiles = Directory.GetFiles(String.Format($"{_mdPredictionsFilePath}", season));
            var filePath = predictionFiles.FirstOrDefault(f => f.Contains(week?.ToString("00") ?? "00"));

            if (string.IsNullOrEmpty(filePath)) return predictions;

            var lines = File.ReadAllLines(filePath);
            var homeTeamFirst = true;

            //Loop through the array
            foreach (var line in lines)
            {
                //Skip the first few lines but get info on how we list the teams in the file
                if (line.StartsWith("Home - Away"))
                {
                    homeTeamFirst = true;
                    continue;
                }
                else if (line.StartsWith("Away - Home"))
                {
                    homeTeamFirst = false;
                    continue;
                }
                else if (line.StartsWith("---"))
                    continue;

                //Split each line at | into an array
                var predictionInfo = line.Split('|');

                //Teams
                var teams = predictionInfo[0].Split(" - ");
                var homeTeam = homeTeamFirst ? teams[0].Trim() : teams[1].Trim();
                var awayTeam = homeTeamFirst ? teams[1].Trim() : teams[0].Trim();
                //Predicted Score
                var score = predictionInfo[1].Split(" - ");
                var homeScore = double.TryParse(homeTeamFirst ? score[0] : score[1], out var parsedHomeScore) ? parsedHomeScore : 0.0;
                var awayScore = double.TryParse(homeTeamFirst ? score[1] : score[0], out var parsedAwayScore) ? parsedAwayScore : 0.0;
                //Pick
                var pick = predictionInfo[3];
                pick = Regex.Replace(pick, "[^A-Za-z0-9 - &-]", "").Trim(); //Use regex to remove unwanted characters
                //Spread
                var spread = awayScore - homeScore;
                //OU
                var ou = awayScore + homeScore;

                var game = new Game(homeTeam, awayTeam, homeScore, awayScore, season, week ?? 0, false, false, new List<Lines> { new Lines(ou, "Taylor", spread, pick) });
                predictions.Add(game);
            }

            return predictions;
        }

        /// <summary>
        /// Creates a dictionary of teams
        /// </summary>
        /// <returns>A dictionary of teams</returns>
        public IDictionary<string, Team> GetTeams(int season)
        {
            var teamDictionary = new Dictionary<string, Team>();

            //Get the array of teams from the txt file
            var filePath = _teamsPath + "FBS-CONF-" + season + ".txt";
            var lines = File.ReadAllLines(filePath);

            //Loop through the array
            foreach (var line in lines)
            {
                //Split each line at | into an array
                var teamInfo = line.Split('|');

                //Fix team names
                var teamName = _nameCorrector.FixName(teamInfo[0]);
                var conference = teamInfo[1];
                var division = teamInfo[2];

                //Add the new team to the dictionary
                teamDictionary.Add(teamName, new Team(teamName, conference, division, new Dictionary<int, Season>()));
            }

            return teamDictionary;
        }

        /// <summary>
        /// Prints the poll to a txt file with table formatting
        /// </summary>
        /// <param name="teams">The teams to print</param>
        public void PrintPollTable(IDictionary<string, Team> teams, int season)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPollFilePath))
                File.Delete(_txtPollFilePath);

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var seasonTeams = new Dictionary<string, Season>();
            seasonTeams = teams.Select(kvp => new KeyValuePair<string, Season>(kvp.Key, kvp.Value.Seasons[season])).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var sortedSeasons = from teamSeason in seasonTeams orderby teamSeason.Value.RatingDetails.Rating descending select teamSeason;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.RatingDetails.Rating;
            var rank = 1;

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Rank | Team | Score | Record\n---|---|---|---");

            //Loop through teams
            foreach (var sortedSeason in sortedSeasons)
            {
                var teamName = sortedSeason.Key;
                var teamSeason = sortedSeason.Value;

                //Add info
                string nextLine = ""
                    + $"{rank} | "
                    + $"{sortedSeason.Key} | "
                    + $"{string.Format("{0:0.0000}", Math.Truncate(teamSeason.RatingDetails.Rating / topRating * 10000) / 10000)} | "
                    + $"{teamSeason.GetWins(teamName).Count() + "-" + teamSeason.GetLosses(teamName).Count()}"
                    + $"\n";

                //Append to csv output
                txt.Append(nextLine);

                //Increment rank
                rank++;
            }

            //Write to output
            File.WriteAllText(_txtPollFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPollFilePath);
        }

        /// <summary>
        /// Prints the predictions to a txt file with table formatting
        /// </summary>
        /// <param name="predictions">The predictions to print</param>
        /// <param name="filePath">Optional parameter for the file path to print the predictions in</param>
        public void PrintPredictionsTable(IEnumerable<Game> predictions, string filePath = "")
        {
            //If the file path for printing the table isn't provided then use the default location
            if (string.IsNullOrEmpty(filePath))
                filePath = _txtPredictionsFilePath;

            //Delete output file if it exists
            if (File.Exists(filePath))
                File.Delete(filePath);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Home - Away | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick\n--- | --- | --- | --- | --- | --- | --- | ---");

            foreach (var prediction in predictions)
            {
                //Determine the winner
                var winner = prediction.HomePoints > prediction.AwayPoints ? prediction.HomeTeam : prediction.AwayTeam;

                //Add info
                string nextLine = ""
                    + $"{prediction.HomeTeam} - {prediction.AwayTeam} | "
                    + $"{Math.Round(prediction.HomePoints, 0)} - {Math.Round(prediction.AwayPoints, 0)} | "
                    + $" | "
                    + $"{winner} | "
                    + $" | "
                    + $" | "
                    + $" | "
                    + $"\n";

                //Append to csv output
                txt.Append(nextLine);
            }

            //Write to output
            File.WriteAllText(_txtPredictionsFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPredictionsFilePath);
        }

        /// <summary>
        /// Prints the results of predictions to a txt file with table formatting
        /// </summary>
        /// <param name="predictions">The predictions to print the results of</param>
        /// <param name="teams">The teams</param>
        /// <param name="season">The season</param>
        public void PrintPredictionsResultsTable(IEnumerable<Game> predictions, IDictionary<string, Team> teams, int season)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPredictionsResultsFilePath))
                File.Delete(_txtPredictionsResultsFilePath);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Home - Away | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick\n--- | --- | --- | --- | --- | --- | --- | ---");

            foreach (var prediction in predictions)
            {
                //Get the matching game for the prediction
                var matchingGame = teams.FirstOrDefault(t => t.Key.Equals(prediction.HomeTeam, _scoic)).Value?.Seasons[season]?
                                    .Games?.FirstOrDefault(g => g.HomeTeam.Equals(prediction.HomeTeam, _scoic) && g.AwayTeam.Equals(prediction.AwayTeam, _scoic));
                if (matchingGame == null) continue;

                //Get our lines for the game. Use Bovada for actual ones if it exists otherwise use the first one
                var gameLine = matchingGame.Lines.FirstOrDefault(l => l.Provider.Equals("Bovada", _scoic));
                if (gameLine == null)
                    gameLine = matchingGame.Lines.FirstOrDefault();
                var predictionLine = prediction.Lines.FirstOrDefault(l => l.Provider.Equals("Taylor", _scoic));

                #region winner determination

                //Compare the predicted winner and the real winner
                var realWinner = matchingGame.HomePoints > matchingGame.AwayPoints ? matchingGame.HomeTeam : matchingGame.AwayTeam;
                var predictedWinner = predictionLine?.Winner ?? (prediction.HomePoints > prediction.AwayPoints ? prediction.HomeTeam : prediction.AwayTeam);
                var winnerResult = predictedWinner.Equals(realWinner, _scoic) ? "✔" : "❌";

                #endregion

                #region spread determination

                //Get the real and prediction spreads
                var realSpread = gameLine?.Spread ?? 0.0;
                var predictedSpread = predictionLine?.Spread ?? 0.0;

                //Build the money line to print in the results using the real spread for the game
                var realMoneyLine = "EVEN";
                //If the spread is > 0 then the away team is favored
                //Print the away team and flip the sign on the spread
                if (realSpread > 0)
                    realMoneyLine = $"{prediction.AwayTeam} {realSpread * -1}";
                //If the spread is < 0 then the home team is favored
                //Print the home team and the spread
                else if (realSpread < 0)
                    realMoneyLine = $"{prediction.HomeTeam} {realSpread}";

                //Result of the game
                var resultMargin = matchingGame.AwayPoints - matchingGame.HomePoints;

                var realSpreadResult = "";
                var predictionSpreadResult = "";
                //If the margin is > 0 then the away team won
                if (resultMargin > 0)
                {
                    //If the away team won by more points than the home team plus the spread (positive) then the away team beat the spread
                    realSpreadResult = matchingGame.AwayPoints > (matchingGame.HomePoints + realSpread) ? matchingGame.AwayTeam : matchingGame.HomeTeam;
                    //If the predicted spread is bigger than the real spread then the prediction is that the away team beats the spread
                    predictionSpreadResult = predictedSpread > realSpread ? prediction.AwayTeam : prediction.HomeTeam;
                }
                //If the margin is < 0 then the home team won
                else if (resultMargin < 0)
                {
                    //If the away team won by more points than the home team plus the spread (negative) then the home team beat the spread
                    realSpreadResult = (matchingGame.HomePoints + realSpread) > matchingGame.AwayPoints ? matchingGame.HomeTeam : matchingGame.AwayTeam;
                    //If the predicted spread is smaller than the game real then the prediction is that the home team beats the spread
                    predictionSpreadResult = predictedSpread < realSpread ? prediction.HomeTeam : prediction.AwayTeam;
                }
                //Compare the prediction vs real
                var spreadResult = predictionSpreadResult.Equals(realSpreadResult, _scoic) ? "✔" : "❌";

                #endregion

                #region over under determination

                //Get real and predicted O/U and compare them to see what is predicted
                var realOverUnder = gameLine?.OverUnder ?? 0.0;
                var predictedOverUnder = predictionLine?.OverUnder ?? 0.0;
                var predictionOverUnderResult = predictedOverUnder > realOverUnder
                                ? "Over" : predictedOverUnder < realOverUnder
                                    ? "Under" : "Push";
                //Compare the actual total points to the O/U
                var combinedScore = matchingGame.HomePoints + matchingGame.AwayPoints;
                var actualOverUnderResult = combinedScore > realOverUnder
                                ? "Over" : combinedScore < realOverUnder
                                    ? "Under" : "Push";
                //Compare the predicted O/U to the real-life result
                var overUnderResult = predictionOverUnderResult.Equals(actualOverUnderResult, _scoic) ? "✔" : "❌";

                #endregion

                //Add info
                string nextLine = ""
                    + $"{prediction.HomeTeam} - {prediction.AwayTeam} | "
                    + $"{prediction.HomePoints} - {prediction.AwayPoints} | "
                    + $"{matchingGame.HomePoints} - {matchingGame.AwayPoints} | "
                    + $"{predictedWinner} {winnerResult} | "
                    + $"{realMoneyLine} | "
                    + $"{predictionSpreadResult} {spreadResult} | "
                    + $"{realOverUnder} | "
                    + $"{predictionOverUnderResult} {overUnderResult}"
                    + $"\n"; 


                //Append to csv output
                txt.Append(nextLine);
            }

            //Write to output
            File.WriteAllText(_txtPredictionsResultsFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPredictionsResultsFilePath);
        }

        #endregion

        /// <summary>
        /// Tries to open a text file in Notepad++ and falls back to Notepad
        /// </summary>
        /// <param name="filePath">The file to open</param>
        private void TryOpenTextFile(string filePath)
        {
            try
            {
                Process.Start(@"C:\Program Files (x86)\Notepad++\notepad++.exe", filePath);
            }
            catch (Exception)
            {
                Process.Start("notepad.exe", _txtPollFilePath);
            }
        }

        #region private methods

        #endregion
    }
}
