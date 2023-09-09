using CFBPoll.Utilities;
using CFBPollDTOs;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;

namespace CFBPoll.Data.Text
{
    public class TextDataModule
    {
        private readonly NameCorrector _nameCorrector;
        private readonly string _teamsPath;
        private readonly string _txtPollFilePath;
        private readonly string _txtPredictionsFilePath;

        public TextDataModule(IConfiguration config, NameCorrector nameCorrector)
        {
            _nameCorrector = nameCorrector;
            _teamsPath = config.GetSection("AppSettings:TeamsPath")?.Value ?? string.Empty;
            _txtPollFilePath = config.GetSection("AppSettings:PollOutputPath_txt")?.Value ?? string.Empty;
            _txtPredictionsFilePath = config.GetSection("AppSettings:PollPredictionsPath_txt")?.Value ?? string.Empty;
        }

        #region public methods

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
            var sortedSeasons = from teamSeason in seasonTeams orderby teamSeason.Value.Rating descending select teamSeason;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.Rating;
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
                    + $"{string.Format("{0:0.0000}", Math.Truncate(teamSeason.Rating / topRating * 10000) / 10000)} | "
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
        public void PrintPredictionsTable(IEnumerable<Game> predictions)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPredictionsFilePath))
                File.Delete(_txtPredictionsFilePath);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Home - Away | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick\n---| ---| ---| ---| ---| ---| ---| ---");

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
