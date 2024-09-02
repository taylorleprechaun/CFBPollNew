using CFBPoll.Utilities;
using CFBPollDTOs;
using CFBPollDTOs.Enums;
using ClosedXML.Excel;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;

namespace CFBPoll.Data.Modules
{
    public class ExcelDataModule
    {
        private readonly string _csvPollFilePath;
        private readonly string _csvPredictionsFilePath;
        private readonly NameCorrector _nameCorrector;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _scoresPath;
        private readonly string _statsPath;

        public ExcelDataModule(IConfiguration config, NameCorrector nameCorrector)
        {
            _nameCorrector = nameCorrector;
            _csvPollFilePath = config.GetSection("AppSettings:PollOutputPath_csv")?.Value ?? string.Empty;
            _csvPredictionsFilePath = config.GetSection("AppSettings:PollPredictionsPath_csv")?.Value ?? string.Empty;
            _scoresPath = config.GetSection("AppSettings:ScoresPath")?.Value ?? string.Empty;
            _statsPath = config.GetSection("AppSettings:StatsPath")?.Value ?? string.Empty;
        }

        #region public methods

        /// <summary>
        /// Gets a list of Game objects from Excel for the given season and week
        /// </summary>
        /// <param name="season">The season</param>
        /// <param name="week">The week</param>
        /// <returns>A list of Game objects</returns>
        public IEnumerable<Game> GetGames(int season, int? week)
        {
            var allGames = new List<Game>();
            var files = Directory.GetFiles($"{_scoresPath}{season}");
            var filePath = string.Empty;
            if (week == null)
                filePath = files.OrderBy(f => f).LastOrDefault();
            else
                filePath = files.FirstOrDefault(f => f.Contains(week?.ToString("00") ?? "00"));

            if (string.IsNullOrEmpty(filePath)) return allGames;

            var scoresTable = GetTableFromExcelFile(filePath);

            foreach (var scoreRow in scoresTable.Rows())
            {
                //Get the team names
                var team1Name = _nameCorrector.FixName(_nameCorrector.RemoveRank(scoreRow.Cell(5).Value.ToString()));
                var team2Name = _nameCorrector.FixName(_nameCorrector.RemoveRank(scoreRow.Cell(8).Value.ToString()));

                //If the team names are Winner and Loser then skip because this is the header row
                if (team1Name.Equals("Winner") && team2Name.Equals("Loser")) continue;

                //Get the week
                int gameWeek;
                if (int.TryParse(scoreRow.Cell(2).Value.ToString(), out var wk))
                    gameWeek = wk;
                else
                    continue;

                //Get the location
                Location team1Location, team2Location;
                var locationValue = scoreRow.Cell(7).Value.ToString();
                if (locationValue.Equals("@"))
                {
                    team1Location = Location.Road;
                    team2Location = Location.Home;
                }
                else if (locationValue.Equals("N"))
                {
                    team1Location = Location.Neutral;
                    team2Location = Location.Neutral;
                }
                else
                {
                    team1Location = Location.Home;
                    team2Location = Location.Road;
                }

                //Get scores
                int.TryParse(scoreRow.Cell(6).Value.ToString(), out int team1Score);
                int.TryParse(scoreRow.Cell(9).Value.ToString(), out int team2Score);

                if (team1Location.Equals(Location.Home))
                    allGames.Add(new Game(team1Name, team2Name, team1Score, team2Score, season, gameWeek, false, team1Score == 0 && team2Score == 0, new List<Lines>()));
                else
                    allGames.Add(new Game(team2Name, team1Name, team2Score, team1Score, season, gameWeek, team1Location.Equals(Location.Neutral), team1Score == 0 && team2Score == 0, new List<Lines>()));
            }

            return allGames;
        }

        /// <summary>
        /// Gets a dictionary of team statistics from Excel for the given type (offense/defense), season, and week
        /// </summary>
        /// <param name="type">The type of statistics (offense/defense)</param>
        /// <param name="season">The season</param>
        /// <param name="week">The week</param>
        /// <returns>A dictionary of team statistics</returns>
        public IDictionary<string, Statistics> GetStatistics(string type, int season, int? week)
        {
            var typeString = type.ToLower().Equals("offense", _scoic) ? "O" : type.ToLower().Equals("defense") ? "D" : null;
            if (string.IsNullOrEmpty(typeString)) return new Dictionary<string, Statistics>();

            var files = Directory.GetFiles($"{_statsPath}{season}");
            var filePath = string.Empty;
            if (week == null)
                filePath = files.OrderBy(f => f).LastOrDefault();
            else
                filePath = files.FirstOrDefault(f => f.Contains(week?.ToString("00") ?? "00") && f.Contains($"Team{typeString}"));

            if (string.IsNullOrEmpty(filePath)) return new Dictionary<string, Statistics>();

            var statsTable = GetTableFromExcelFile(filePath);
            return BuildStats(statsTable);
        }

        /// <summary>
        /// Print the poll details to a CSV file
        /// </summary>
        /// <param name="teams">The teams to print</param>
        public void PrintPollDetails(IDictionary<string, Team> teams, int season)
        {
            //Delete output file if it exists
            if (File.Exists(_csvPollFilePath))
                File.Delete(_csvPollFilePath);

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var seasonTeams = new Dictionary<string, Season>();
            seasonTeams = teams.Select(kvp => new KeyValuePair<string, Season>(kvp.Key, kvp.Value.Seasons[season])).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var sortedSeasons = from teamSeason in seasonTeams orderby teamSeason.Value.RatingDetails.Rating descending select teamSeason;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.RatingDetails.Rating;
            var rank = 1;

            //CSV header
            var csv = new StringBuilder();
            csv.AppendLine("Number,Team,Score,Points,W,L,Pct,SoS,Weighted,Conf,Div,AvgMoV,YF,YA,TO Margin,YPPO,YPPD");

            //Loop through teams
            foreach (var sortedSeason in sortedSeasons)
            {
                var teamName = sortedSeason.Key;
                var teamSeason = sortedSeason.Value;

                //Add info
                string nextLine = ""
                    + $"{rank},"
                    + $"{teamName},"
                    + $"{teamSeason.RatingDetails.Rating:0.0000},"
                    + $"{teamSeason.RatingDetails.Rating / topRating:0.0000},"
                    + $"{teamSeason.GetWins(teamName).Count()},"
                    + $"{teamSeason.GetLosses(teamName).Count()},"
                    + $"{teamSeason.GetWins(teamName).Count() / Convert.ToDouble(teamSeason.GetPlayedGames().Count()):0.0000},"
                    + $"{teamSeason.RatingDetails.StrengthOfSchedule:0.0000},"
                    + $"{teamSeason.RatingDetails.WeightedStrengthOfSchedule:0.0000},"
                    + $"{teams[teamName].Conference},"
                    + $"{teams[teamName].Division},"
                    + $"{teamSeason.RatingDetails.OffenseStatistics.Points - teamSeason.RatingDetails.DefenseStatistics.Points},"
                    + $"{teamSeason.RatingDetails.OffenseStatistics.TotalYards},"
                    + $"{teamSeason.RatingDetails.DefenseStatistics.TotalYards},"
                    + $"{teamSeason.RatingDetails.OffenseStatistics.TotalTO - teamSeason.RatingDetails.DefenseStatistics.TotalTO},"
                    + $"{teamSeason.RatingDetails.OffenseStatistics.TotalYards / teamSeason.RatingDetails.OffenseStatistics.Plays:0.0000},"
                    + $"{teamSeason.RatingDetails.DefenseStatistics.TotalYards / teamSeason.RatingDetails.DefenseStatistics.Plays:0.0000}"
                    + $"\n";

                //Append to csv output
                csv.Append(nextLine);

                //Increment rank
                rank++;
            }

            //Write to output
            File.WriteAllText(_csvPollFilePath, csv.ToString());

            //Open the file
            TryOpenCSVFile(_csvPollFilePath);
        }

        /// <summary>
        /// Prints the predictions details to a CSV file
        /// </summary>
        /// <param name="predictions">The predictions to print</param>
        public void PrintPredictionDetails(IEnumerable<Game> predictions)
        {
            //Delete output file if it exists
            if (File.Exists(_csvPredictionsFilePath))
                File.Delete(_csvPredictionsFilePath);

            //Table header
            var csv = new StringBuilder();
            csv.AppendLine("Home,HomeScore,Location,Away Score,Away,Pick,Actual Spread,Prediction Spread,Actual O/U,Prediction O/U");

            foreach (var prediction in predictions)
            {
                //Determine the winner
                var winner = prediction.HomePoints > prediction.AwayPoints ? prediction.HomeTeam : prediction.AwayTeam;

                var bettingInfoToPrint = prediction.Lines.FirstOrDefault(b => b.Provider.Equals("Bovada", _scoic));
                if (bettingInfoToPrint == null)
                    bettingInfoToPrint = prediction.Lines.FirstOrDefault(b => b.IsValid());

                //Add info
                string nextLine = ""
                    + $"{prediction.HomeTeam},{Math.Round(prediction.HomePoints, 2)},"
                    + $"{(prediction.NeutralSite ? $"VS" : $"")},"
                    + $"{Math.Round(prediction.AwayPoints, 2)},{prediction.AwayTeam},"
                    + $"{winner},"
                    + $"{bettingInfoToPrint?.Spread ?? -1.0},"
                    + $"{Math.Round(prediction.AwayPoints - prediction.HomePoints, 2)},"
                    + $"{bettingInfoToPrint?.OverUnder ?? -1.0},"
                    + $"{Math.Round(prediction.HomePoints + prediction.AwayPoints, 2)},"
                    + $"\n";

                //Append to csv output
                csv.Append(nextLine);
            }

            //Write to output
            File.WriteAllText(_csvPredictionsFilePath, csv.ToString());

            //Open the file
            TryOpenCSVFile(_csvPredictionsFilePath);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Builds a dictionary of statistics from the given statistics table
        /// </summary>
        /// <param name="statTable">The statistics table</param>
        /// <returns>A dictionary of team names and their statistics</returns>
        private IDictionary<string, Statistics> BuildStats(IXLTable statTable)
        {
            var statDictionary = new Dictionary<string, Statistics>();

            //For reach row in the stat table
            foreach (var statRow in statTable.Rows())
            {
                //Check if the team name in the row is "School" (first row of the table) or null/empty
                var teamName = _nameCorrector.FixName(statRow.Cell(2).Value.ToString());
                if (teamName.Equals("School") || string.IsNullOrEmpty(teamName))
                {
                    continue;
                }

                statDictionary.Add(teamName, new Statistics()
                {
                    //Index 1 = Rank which is is useless
                    //Index 2 = School which we already know
                    Games = int.Parse(statRow.Cell(3).Value.ToString()),
                    Points = double.Parse(statRow.Cell(4).Value.ToString()),
                    PassCompletions = double.Parse(statRow.Cell(5).Value.ToString()),
                    PassAttempts = double.Parse(statRow.Cell(6).Value.ToString()),
                    PassPercent = double.Parse(statRow.Cell(7).Value.ToString()),
                    PassYards = double.Parse(statRow.Cell(8).Value.ToString()),
                    PassTD = double.Parse(statRow.Cell(9).Value.ToString()),
                    RushAttempts = double.Parse(statRow.Cell(10).Value.ToString()),
                    RushYards = double.Parse(statRow.Cell(11).Value.ToString()),
                    RushAvg = double.Parse(statRow.Cell(12).Value.ToString()),
                    RushTD = double.Parse(statRow.Cell(13).Value.ToString()),
                    Plays = double.Parse(statRow.Cell(14).Value.ToString()),
                    TotalYards = double.Parse(statRow.Cell(15).Value.ToString()),
                    //Index 16 = Total Off/Def Avg = TotalYards/Plays
                    PassFirsts = double.Parse(statRow.Cell(17).Value.ToString()),
                    RushFirsts = double.Parse(statRow.Cell(18).Value.ToString()),
                    PenaltyFirsts = double.Parse(statRow.Cell(19).Value.ToString()),
                    TotalFirsts = double.Parse(statRow.Cell(20).Value.ToString()),
                    Penalties = double.Parse(statRow.Cell(21).Value.ToString()),
                    PenaltyYards = double.Parse(statRow.Cell(22).Value.ToString()),
                    Fumbles = double.Parse(statRow.Cell(23).Value.ToString()),
                    Interceptions = double.Parse(statRow.Cell(24).Value.ToString()),
                    TotalTO = double.Parse(statRow.Cell(25).Value.ToString()),
                });
            }

            return statDictionary;
        }

        /// <summary>
        /// Gets the table from the given Excel file
        /// </summary>
        /// <param name="filePath">The Excel file path</param>
        /// <returns>An IXLTable from the given file path</returns>
        private IXLTable GetTableFromExcelFile(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var excelFile = new XLWorkbook(fileStream);
            var excelSheet = excelFile.Worksheets.Worksheet("Sheet2");
            return excelSheet.Table(0);
        }

        /// <summary>
        /// Tries to open a CSV file in Excel
        /// </summary>
        /// <param name="filePath">The file to open</param>
        private void TryOpenCSVFile(string filePath)
        {
            try
            {
                Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\EXCEL.exe", filePath);
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to open file: {filePath}.");
            }
        }

        #endregion
    }
}
