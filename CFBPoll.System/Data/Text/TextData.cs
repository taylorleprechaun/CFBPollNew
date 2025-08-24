using CFBPoll.DTOs;
using CFBPoll.System.Utilities;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace CFBPoll.System.Data.Text
{
    public class TextData
    {
        private readonly NameCorrector _nameCorrector;
        private readonly string _mdPredictionsFilePath = string.Empty;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _teamsPath = string.Empty;
        private readonly string _txtPollFilePath = string.Empty;
        private readonly string _txtPredictionsFilePath = string.Empty;
        private readonly string _txtPredictionsResultsFilePath = string.Empty;

        public TextData(NameCorrector nameCorrector)
        {
            _nameCorrector = nameCorrector;
        }

        public TextData(IConfiguration config, NameCorrector nameCorrector)
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
        /// Gets predictions made previously from a file.
        /// </summary>
        /// <param name="season">The season for the predictions.</param>
        /// <param name="week">The week for the predictions.</param>
        /// <returns>A list of Games containing the game information and the predicted betting lines.</returns>
        public IEnumerable<Game> GetPredictions(int season, int? week)
        {
            var predictions = new List<Game>();

            //Get the predictions from the directory
            var predictionFiles = Directory.GetFiles(string.Format($"{_mdPredictionsFilePath}", season));
            var filePath = predictionFiles.FirstOrDefault(f => f.Contains($"Week {week?.ToString("00") ?? "00"}"));

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
                
                //Betting Provider Lines
                //Spread
                double.TryParse(predictionInfo[4].Trim().Split(' ').Last(), out var spread);
                //OU
                double.TryParse(predictionInfo[6], out var ou);
                var bettingLine = new Lines(ou, "GameLine", spread, pick);

                //My Lines
                //Spread
                spread = awayScore - homeScore;
                //OU
                ou = awayScore + homeScore;
                var myLine = new Lines(ou, "Taylor", spread, pick);

                var game = new Game(homeTeam, awayTeam, homeScore, awayScore, season, week ?? 0, false, false, new List<Lines> { bettingLine, myLine });
                predictions.Add(game);
            }

            return predictions;
        }

        /// <summary>
        /// Creates a dictionary of teams.
        /// </summary>
        /// <returns>A dictionary of teams.</returns>
        public IDictionary<string, Team> GetTeams(int season)
        {
            //Build the path to the file data
            var filePath = _teamsPath + "FBS-CONF-" + season + ".txt";

            return GetTeams(filePath);
        }

        /// <summary>
        /// Gets a dictionary of teams from a file.
        /// </summary>
        /// <param name="filePath">The path to the file of team information.</param>
        /// <returns>A dictionary of teams.</returns>
        public IDictionary<string, Team> GetTeams(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var teamDictionary = new Dictionary<string, Team>();

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
        /// Prints the poll to a txt file with table formatting.
        /// </summary>
        /// <param name="teams">The teams to print.</param>
        public void PrintPollTable(IDictionary<string, Team> teams, int season)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPollFilePath))
                File.Delete(_txtPollFilePath);

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var seasonTeams = new Dictionary<string, Season>();
            seasonTeams = teams.Select(kvp => kvp.Value.Seasons.ContainsKey(season)
                                    ? new KeyValuePair<string, Season>(kvp.Key, kvp.Value.Seasons[season])
                                    : new KeyValuePair<string, Season>(kvp.Key, new Season(kvp.Key, season)))
                               .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var sortedSeasons = from teamSeason in seasonTeams orderby teamSeason.Value.RatingDetails.Rating descending select teamSeason;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.RatingDetails.Rating;
            var rank = 1;

            //Sort strength of schedule for printing
            var sosRank = 1;
            var strengthOfScheduleRankings = sortedSeasons.OrderByDescending(s => s.Value.RatingDetails.WeightedStrengthOfSchedule).ToDictionary(s => s.Key, s => sosRank++);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Rank | Team | Rating | Record | SoS | SoS Rank\n---|---|---|---|---|---");

            //Loop through teams
            for (int ii = 0; ii < sortedSeasons.Count(); ii++)
            {
                var sortedSeason = sortedSeasons.ElementAt(ii);
                var teamName = sortedSeason.Key;
                var teamSeason = sortedSeason.Value;

                //Add info
                string nextLine = ""
                    + $"{rank} | "
                    + $"{sortedSeason.Key} | "
                    + $"{string.Format("{0:0.0000}", Math.Truncate(teamSeason.RatingDetails.Rating / topRating * 10000) / 10000)} | "
                    + $"{teamSeason.GetWins(teamName).Count() + "-" + teamSeason.GetLosses(teamName).Count()} | "
                    + $"{string.Format("{0:0.0000}", teamSeason.RatingDetails.WeightedStrengthOfSchedule)} | "
                    + $"{strengthOfScheduleRankings[teamName]}"
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
        /// Prints the predictions to a txt file with table formatting.
        /// </summary>
        /// <param name="predictions">The predictions to print.</param>
        /// <param name="filePath">Optional parameter for the file path to print the predictions in.</param>
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

                //Get the betting info to print
                var bettingInfoToPrint = prediction.Lines.FirstOrDefault(b => b.Provider.Equals("Bovada", _scoic));
                bettingInfoToPrint ??= prediction.Lines.FirstOrDefault(b => b.IsValid());

                //Get the spread and make our pick against it
                var spread = bettingInfoToPrint?.Spread ?? -1.0;
                var spreadPick = spread < 0 ? prediction.HomeTeam : prediction.AwayTeam;
                var atsPick = !spread.Equals(-1.0)
                                ? Math.Round(prediction.AwayPoints, 0) - Math.Round(prediction.HomePoints, 0) >= spread ? prediction.AwayTeam : prediction.HomeTeam
                                : string.Empty;
                //Get the over/under and make our pick against it
                var overUnder = bettingInfoToPrint?.OverUnder ?? -1.0;
                var overUnderPick = !overUnder.Equals(-1.0)
                                    ? Math.Round(prediction.HomePoints, 0) + Math.Round(prediction.AwayPoints, 0) >= overUnder ? "Over" : "Under"
                                    : string.Empty;

                //Add info
                string nextLine = ""
                    + $"{prediction.HomeTeam} - {prediction.AwayTeam} | "
                    + $"{Math.Round(prediction.HomePoints, 0)} - {Math.Round(prediction.AwayPoints, 0)} | "
                    + $" | "
                    + $"{winner} | "
                    + $"{spreadPick} {spread} | "
                    + $"{atsPick} | "
                    + $"{overUnder} | "
                    + $"{overUnderPick}"
                    + "\n";

                //Append to csv output
                txt.Append(nextLine);
            }

            //Write to output
            File.WriteAllText(_txtPredictionsFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPredictionsFilePath);
        }

        /// <summary>
        /// Prints the results of predictions to a txt file with table formatting.
        /// </summary>
        /// <param name="predictions">The predictions to print the results of.</param>
        /// <param name="teams">The teams.</param>
        /// <param name="season">The season.</param>
        public void PrintPredictionsResultsTable(IEnumerable<Game> predictions, IDictionary<string, Team> teams, int season)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPredictionsResultsFilePath))
                File.Delete(_txtPredictionsResultsFilePath);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Home - Away | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick\n--- | --- | --- | --- | --- | --- | --- | ---");

            var totalCount = 0;
            var winnerCount = 0;
            var spreadCount = 0;
            var overUnderCount = 0;

            foreach (var prediction in predictions)
            {
                //Get the matching game for the prediction
                var matchingGame = teams.FirstOrDefault(t => t.Key.Equals(prediction.HomeTeam, _scoic)).Value?.Seasons[season]?
                                    .Games?.FirstOrDefault(g => g.HomeTeam.Equals(prediction.HomeTeam, _scoic) && g.AwayTeam.Equals(prediction.AwayTeam, _scoic));
                if (matchingGame == null) continue;

                //Get the lines for the game that we predicted against
                var pregameLine = prediction.Lines.FirstOrDefault(l => l.Provider.Equals("GameLine", _scoic));
                var myLine = prediction.Lines.FirstOrDefault(l => l.Provider.Equals("Taylor", _scoic));
                var realLine = new Lines()
                {
                    OverUnder = matchingGame.HomePoints + matchingGame.AwayPoints,
                    Provider = "Real",
                    Spread = matchingGame.AwayPoints - matchingGame.HomePoints,
                    Winner = matchingGame.HomePoints > matchingGame.AwayPoints ? matchingGame.HomeTeam : matchingGame.AwayTeam,
                };

                #region winner determination

                //Compare the predicted winner and the real winner
                var realWinner = realLine.Winner;
                var predictedWinner = myLine?.Winner ?? (prediction.HomePoints > prediction.AwayPoints ? prediction.HomeTeam : prediction.AwayTeam);
                var winnerResult = predictedWinner.Equals(realWinner, _scoic) ? "✔" : "❌";

                #endregion

                #region spread determination

                //Get the real and prediction spreads
                var pregameSpread = pregameLine?.Spread ?? 0.0;
                var mySpread = myLine?.Spread ?? 0.0;

                var realSpreadPick = pregameSpread < 0 ? matchingGame.HomeTeam : matchingGame.AwayTeam;
                var pregameSpreadPick = "";
                var realSpreadResult = "";
                var predictionSpreadResult = "";
                
                //If the pregame spread is > 0 then the road team is predicted to have won
                if (pregameSpread > 0)
                {
                    //Pregame spread pick
                    pregameSpreadPick = prediction.HomePoints > prediction.AwayPoints + pregameSpread ? matchingGame.HomeTeam : matchingGame.AwayTeam;
                    //If my spread is less than the pregame spread then I predicted the home team to cover
                    predictionSpreadResult = mySpread > pregameSpread ? matchingGame.AwayTeam : matchingGame.HomeTeam;
                    //If the home team won by more points than the away team plus the spread then the home team beat the spread
                    realSpreadResult = matchingGame.HomePoints > matchingGame.AwayPoints - pregameSpread ? matchingGame.HomeTeam : matchingGame.AwayTeam;
                }
                //If the pregame spread is < 0 then the home team is predicted to have won
                else if (pregameSpread < 0)
                {
                    //Pregame spread pick
                    pregameSpreadPick = prediction.AwayPoints >= prediction.HomePoints + pregameSpread ? matchingGame.AwayTeam : matchingGame.HomeTeam;
                    //If my spread is greater than the pregame spread then I predicted the away team to cover
                    predictionSpreadResult = mySpread >= pregameSpread ? matchingGame.AwayTeam : matchingGame.HomeTeam;
                    //If the away team won by more points than the home team plus the spread then the away team beat the spread
                    realSpreadResult = matchingGame.AwayPoints >= matchingGame.HomePoints + pregameSpread ? matchingGame.AwayTeam : matchingGame.HomeTeam;
                }
                //Compare the prediction vs real
                var spreadResult = predictionSpreadResult.Equals(realSpreadResult, _scoic) ? "✔" : "❌";

                #endregion

                #region over under determination

                //Get real and predicted O/U and compare them to see what is predicted
                var realOverUnder = matchingGame.HomePoints + matchingGame.AwayPoints;
                var myOverUnder = myLine?.OverUnder ?? 0.0;
                var pregameOverUnder = pregameLine?.OverUnder ?? 0.0;

                var predictedOverUnder = myOverUnder >= pregameOverUnder ? "Over" : "Under";
                var actualOverUnder = realOverUnder > pregameOverUnder
                                ? "Over" : realOverUnder < pregameOverUnder
                                    ? "Under" : "Push";
                //Compare the predicted O/U to the real-life result
                var overUnderResult = predictedOverUnder.Equals(actualOverUnder, _scoic) ? "✔" : "❌";

                #endregion

                //Add info
                var nextLine = ""
                    + $"{prediction.HomeTeam} - {prediction.AwayTeam} | "
                    + $"{prediction.HomePoints} - {prediction.AwayPoints} | "
                    + $"{matchingGame.HomePoints} - {matchingGame.AwayPoints} | "
                    + $"{predictedWinner} {winnerResult} | "
                    + $"{realSpreadPick} {pregameSpread} | "
                    + $"{predictionSpreadResult} {spreadResult} | "
                    + $"{pregameOverUnder} | "
                    + $"{predictedOverUnder} {overUnderResult}"
                    + $"\n"; 


                //Append to csv output
                txt.Append(nextLine);

                //Tally Results
                if (winnerResult.Equals("✔", _scoic)) winnerCount++;
                if (spreadResult.Equals("✔", _scoic)) spreadCount++;
                if (overUnderResult.Equals("✔", _scoic)) overUnderCount++;
                totalCount++;
            }

            var newLine = "\n\n"
                + "Results:\n"
                + $"* Winner: {winnerCount} - {totalCount - winnerCount} ({decimal.Divide(winnerCount, totalCount):P1})\n"
                + $"* ATS: {spreadCount} - {totalCount - spreadCount} ({decimal.Divide(spreadCount,totalCount):P1})\n"
                + $"* O/U: {overUnderCount} - {totalCount - overUnderCount} ({decimal.Divide(overUnderCount, totalCount):P1})\n";

            txt.Append(newLine);

            //Write to output
            File.WriteAllText(_txtPredictionsResultsFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPredictionsResultsFilePath);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Tries to open a text file in Notepad++ and falls back to Notepad.
        /// </summary>
        /// <param name="filePath">The file to open.</param>
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

        #endregion
    }
}
