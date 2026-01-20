using CFBPoll.DTOs;
using CFBPoll.DTOs.Rating;
using CFBPoll.DTOs.Scenarios;
using CFBPoll.Utilities;
using CollegeFootballData.Models;
using OfficeOpenXml;
using System.Diagnostics;

namespace CFBPoll.System.Data.SpreadsheetData
{
    public class SpreadsheetData
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _xlsxPollFilePath;
        private readonly string _xlsxScenariosFilePath;
        
        public SpreadsheetData()
        {
            _xlsxPollFilePath = ConfigurationHelper.GetConfiguration("PollOutputPath_xlsx");
            _xlsxScenariosFilePath = ConfigurationHelper.GetConfiguration("ScenarioOutputPath_xlsx");
            ExcelPackage.License.SetNonCommercialPersonal("Taylor Steinberg");
        }

        #region public methods

        /// <summary>
        /// Print the poll details to a workbook file.
        /// </summary>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        public void PrintPollDetails(IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails, int season, int week)
        {
            //Delete output file if it exists
            if (File.Exists(_xlsxPollFilePath))
                File.Delete(_xlsxPollFilePath);

            using (var workbook = new ExcelPackage(_xlsxPollFilePath))
            {
                BuildRatingDetails(workbook, teamInfo, ratingDetails);
                BuildConferenceDetails(workbook, teamInfo, ratingDetails);
                BuildTeamWinDetails(workbook, teamInfo, ratingDetails, season, week);

                var newFile = new FileInfo(_xlsxPollFilePath);
                workbook.SaveAs(_xlsxPollFilePath);
            }

            TryOpenSpreadsheetFile(_xlsxPollFilePath);
        }

        /// <summary>
        /// Print the scenario details to a workbook file.
        /// </summary>
        /// <param name="scenarios">The scenarios to print.</param>
        /// <param name="teamDetails">Team information.</param>
        public void PrintScenarioDetails(IEnumerable<ScenarioResult> scenarios, IDictionary<string, TeamDetail> teamInfo)
        {
            //Delete output file if it exists
            if (File.Exists(_xlsxScenariosFilePath))
                File.Delete(_xlsxScenariosFilePath);

            using (var workbook = new ExcelPackage(_xlsxScenariosFilePath))
            {
                BuildScenarioDetails(workbook, scenarios, teamInfo);

                var newFile = new FileInfo(_xlsxScenariosFilePath);
                workbook.SaveAs(_xlsxScenariosFilePath);
            }

            TryOpenSpreadsheetFile(_xlsxScenariosFilePath);
        }

        #endregion

        #region private poll methods

        /// <summary>
        /// Build the Conference Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Conference Details tab to.</param>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        private void BuildConferenceDetails(ExcelPackage workbook, IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Conference Details");

            //Data to print in the conference details
            var conferences = teamInfo.Values.Where(t => !string.IsNullOrEmpty(t?.TeamInfo?.Conference)).Select(t => t.TeamInfo.Conference).Distinct().OrderBy(c => c);
            var ratings = ratingDetails.ToDictionary(r => r.Key, r => r.Value.Rating);
            var rankings = ratings.OrderByDescending(r => r.Value)
                                    .Select((r, index) => new { r.Key, Rank = index + 1 })
                                    .ToDictionary(r => r.Key, r => r.Rank);
            var strengthsOfSchedule = ratingDetails.ToDictionary(r => r.Key, r => r.Value.StrengthOfSchedule?.WeightedStrength ?? 0.0);

            //Set the worksheet headers
            var headers = new List<string>
            {
                "Conference", "Number of Teams",
                "Highest Rank", "Lowest Rank", "Average Rank",
                "Highest Rating", "Lowest Rating", "Average Rating",
                "Highest Weighted SoS", "Lowest Weighted SoS", "Average Weighted SoS",
            };
            int col = 1;
            foreach (var header in headers)
            {
                sheet.Cells[1, col++].Value = header;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            foreach (var conference in conferences)
            {
                var conferenceTeams = teamInfo.Values.Where(t => t?.TeamInfo?.Conference?.Equals(conference, _scoic) == true && !string.IsNullOrEmpty(t?.TeamInfo?.School)).Select(t => t.TeamInfo.School);
                if (conferenceTeams == null || !conferenceTeams.Any())
                    continue;

                var conferenceRatings = ratings.Where(r => conferenceTeams.Contains(r.Key)).OrderBy(r => r.Value);
                var conferenceRankings = rankings.Where(r => conferenceTeams.Contains(r.Key)).OrderBy(r => r.Value);
                var conferenceStrengthsOfSchedule = strengthsOfSchedule.Where(r => conferenceTeams.Contains(r.Key)).OrderBy(r => r.Value);

                //Excel formulas for stats rather than doing the calculations in code
                //Conference Name
                sheet.Cells[row, col++].Value = conference;
                //Number of Teams
                sheet.Cells[row, col++].Value = conferenceTeams.Count();
                //Highest Rank (lowest number)
                sheet.Cells[row, col++].Value = conferenceRankings.Min(r => r.Value);
                //Lowest Rank (highest number)
                sheet.Cells[row, col++].Value = conferenceRankings.Max(r => r.Value);
                //Average Rank
                sheet.Cells[row, col].Style.Numberformat.Format = "0.00";
                sheet.Cells[row, col++].Value = conferenceRankings.Average(r => r.Value);
                //Highest Rating (largest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceRatings.Max(r => r.Value);
                //Lowest Rating (smallest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceRatings.Min(r => r.Value);
                //Average Rating
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceRatings.Average(r => r.Value);
                //Highest Weighted SoS (largest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceStrengthsOfSchedule.Max(s => s.Value);
                //Lowest Weighted SoS (smallest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceStrengthsOfSchedule.Min(s => s.Value);
                //Average Weighted SoS
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Value = conferenceStrengthsOfSchedule.Average(s => s.Value);

                //Reset the column to the start and increment the row
                col = 1;
                row++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }

        /// <summary>
        /// Build the Rating Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Rating Details tab to.</param>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        private void BuildRatingDetails(ExcelPackage workbook, IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Rating Details");

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var sortedTeamRatings = from teamRating in ratingDetails
                                orderby teamRating.Value.Rating descending
                                select teamRating;

            //Get the highest ranking
            var topRating = sortedTeamRatings.FirstOrDefault().Value.Rating;
            var rank = 1;

            //Set the worksheet headers
            var headers = new List<string>
            {
                "Ranking", "Team Name", "Rating", "Rating Percentage",
                "Wins", "Losses", "Percentage", "Strength of Schedule", "Weighted SoS",
                "Conference", "Division"
            };
            headers.AddRange(sortedTeamRatings.FirstOrDefault().Value.RatingComponents.Keys);
            int col = 1;
            foreach (var header in headers)
            {
                sheet.Cells[1,col++].Value = header;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            foreach (var sortedTeamRating in sortedTeamRatings)
            {
                var teamName = sortedTeamRating.Key;
                var teamSeason = sortedTeamRating.Value;

                //Ranking
                sheet.Cells[row, col++].Value = rank;
                //Team Name
                sheet.Cells[row, col++].Value = teamName;
                //Rating
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Rating, 4);
                //Rating Percentage
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Rating / topRating, 4);
                //Wins
                sheet.Cells[row, col++].Value = teamSeason.Wins;
                //Losses
                sheet.Cells[row, col++].Value = teamSeason.Losses;
                //Percentage
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Wins / Convert.ToDouble(teamSeason.Wins + teamSeason.Losses), 3);
                //Strength of Schedule
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.StrengthOfSchedule.Strength, 4);
                //Weighted SoS
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.StrengthOfSchedule.WeightedStrength, 4);
                //Conference
                sheet.Cells[row, col++].Value = teamInfo[teamName].TeamInfo.Conference;
                //Division
                sheet.Cells[row, col++].Value = teamInfo[teamName].TeamInfo.Division;
                //Rating Components
                foreach (var component in teamSeason.RatingComponents.Values)
                {
                    sheet.Cells[row, col++].Value = Math.Round(component, 2);
                }
                
                //Reset the column to the start and increment the row and rank
                col = 1;
                row++;
                rank++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }


        /// <summary>
        /// Build the Team Win Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Win Details tab to.</param>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        private void BuildTeamWinDetails(ExcelPackage workbook, IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails, int season, int week)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Win Details");

            //Data to print in the win details
            var conferences = teamInfo.Values.Select(t => t.TeamInfo.Conference).Distinct().OrderBy(c => c);
            var rankings = ratingDetails.ToDictionary(r => r.Key, r => r.Value.Rating)
                                    .OrderByDescending(r => r.Value)
                                    .Select((r, index) => new { r.Key, Rank = index + 1 })
                                    .ToDictionary(r => r.Key, r => r.Rank);

            //Calculate a team's wins and losses
            Func<string, Game, string> GetOpponent = (teamName, game) =>
            {
                if (string.IsNullOrEmpty(teamName) || string.IsNullOrEmpty(game?.HomeTeam) || string.IsNullOrEmpty(game?.AwayTeam))
                    return string.Empty;
                return (game!.HomeTeam!.Equals(teamName, _scoic) ? game.AwayTeam : game.HomeTeam) ?? string.Empty;
            };
            Func<string, Game, int> GetPointsFor = (teamName, game) =>
            {
                if (string.IsNullOrEmpty(teamName) || string.IsNullOrEmpty(game?.HomeTeam) || string.IsNullOrEmpty(game?.AwayTeam))
                    return 0;
                return (game!.HomeTeam!.Equals(teamName, _scoic) ? game.HomePoints : game.AwayPoints) ?? 0;
            };
            //Calculate a team's record vs a range of ranks
            Func<string, IEnumerable<Game>, int, int, string> GetRecordVsRankRange = (teamName, games, minRank, maxRank) =>
            {
                if (string.IsNullOrEmpty(teamName) || games == null || !games.Any() || minRank > maxRank)
                    return "0-0";

                int wins = 0, losses = 0;
                foreach (var game in games)
                {
                    if (game == null)
                        continue;

                    var opponent = GetOpponent(teamName, game);
                    if (string.IsNullOrEmpty(opponent) || !rankings.ContainsKey(opponent))
                        continue;

                    var opponentRank = rankings[opponent];
                    if (opponentRank < minRank || opponentRank > maxRank)
                        continue;

                    int teamPoints = GetPointsFor(teamName, game);
                    int opponentPoints = GetPointsFor(opponent, game);

                    if (teamPoints > opponentPoints)
                        wins++;
                    else if (teamPoints < opponentPoints)
                        losses++;
                }
                return $"{wins}-{losses}";
            };
            //Calculate a team's record vs non-FBS opponents
            Func<string, IEnumerable<Game>, string> GetRecordVsNonFBS = (teamName, games) =>
            {
                if (string.IsNullOrEmpty(teamName) || games == null || !games.Any())
                    return "0-0";

                int wins = 0, losses = 0;
                foreach (var game in games)
                {
                    if (game == null)
                        continue;

                    var opponent = GetOpponent(teamName, game);
                    if (string.IsNullOrEmpty(opponent) || game.AwayTeam?.Equals(opponent, _scoic) == true && game.AwayClassification?.Equals(DivisionClassification.Fbs) == true
                        || game.HomeTeam?.Equals(opponent, _scoic) == true && game.HomeClassification?.Equals(DivisionClassification.Fbs) == true)
                        continue;

                    int teamPoints = GetPointsFor(teamName, game);
                    int opponentPoints = GetPointsFor(opponent, game);

                    if (teamPoints > opponentPoints)
                        wins++;
                    else if (teamPoints < opponentPoints)
                        losses++;
                }
                return $"{wins}-{losses}";
            };

            //Set the worksheet headers
            var headers = new List<string>
            {
                "Rank", "Team Name", "vs 1-25", "vs 26-50", "vs 50-100", $"vs 100-{teamInfo.Count}", "vs FCS/Other"
            };
            int col = 1;
            foreach (var header in headers)
            {
                sheet.Cells[1, col++].Value = header;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            foreach (var ranking in rankings)
            {
                var teamName = ranking.Key;
                var rank = ranking.Value;

                var teamGames = teamInfo[teamName].Games.Where(g => g != null && g.Season == season && g.Week <= week && g.Completed == true);

                //Ranking
                sheet.Cells[row, col++].Value = rank;
                //Team Name
                sheet.Cells[row, col++].Value = teamName;
                //Wins vs 1-25
                sheet.Cells[row, col++].Value = GetRecordVsRankRange(teamName, teamGames, 1, 25);
                //Wins vs 26-50
                sheet.Cells[row, col++].Value = GetRecordVsRankRange(teamName, teamGames, 26, 50);
                //Wins vs 51-100
                sheet.Cells[row, col++].Value = GetRecordVsRankRange(teamName, teamGames, 51, 100);
                //Wins vs 101+
                sheet.Cells[row, col++].Value = GetRecordVsRankRange(teamName, teamGames, 101, rankings.Count);
                //Wins vs FCS
                sheet.Cells[row, col++].Value = GetRecordVsNonFBS(teamName, teamGames);

                //Reset the column to the start and increment the row and rank
                col = 1;
                row++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }

        #endregion

        #region private scenario methods

        /// <summary>
        /// Build the Scenario Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Scenario Details tab to.</param>
        /// <param name="scenarios">The scenarios to print.</param>
        /// <param name="teamInfo">Team information.</param>
        private void BuildScenarioDetails(ExcelPackage workbook, IEnumerable<ScenarioResult> scenarios, IDictionary<string, TeamDetail> teamInfo)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Scenario Details");
            if (scenarios?.Any() != true || teamInfo?.Any() != true)
                return;

            //Get the scenario details to print
            var gameIDs = scenarios?.FirstOrDefault()?.GameIDs ?? new List<int?>();
            var gameDictionary = teamInfo?.Values?.SelectMany(t => t?.Games ?? new List<Game>())?
                                                .Where(g => !string.IsNullOrEmpty(g?.HomeTeam) && !string.IsNullOrEmpty(g?.AwayTeam) && g?.Id != null && gameIDs.Contains(g.Id))?
                                                .DistinctBy(g => g.Id)?
                                                .ToDictionary(g => g!.Id!.Value, g => g) ?? new Dictionary<int, Game>();
            var scenarioGames = new SortedDictionary<int, Game>(gameDictionary);
            if (scenarioGames?.Any() != true)
                return;

            //Set the worksheet header as each matchup
            int col = 1;
            foreach (var scenarioGame in scenarioGames.Values)
            {
                if (string.IsNullOrEmpty(scenarioGame?.AwayTeam) || string.IsNullOrEmpty(scenarioGame?.HomeTeam) || scenarioGame?.NeutralSite == null)
                    continue;

                sheet.Cells[1, col].Style.Font.Bold = true;
                sheet.Cells[1, col++].Value = $"{scenarioGame.AwayTeam} {(scenarioGame.NeutralSite == true ? "vs" : "@")} {scenarioGame.HomeTeam}";
            }
            //Add the rankings to the header as well
            int rank = 1;
            while (rank <= teamInfo!.Count)
            {
                sheet.Cells[1, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells[1, col].Style.Font.Bold = true;
                sheet.Cells[1, col++].Value = rank++;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            foreach (var scenario in scenarios!)
            {
                if (scenario?.Scenario?.Any() != true)
                    continue;

                //Print the winner of each scenario following the same order as the sorted games
                var isScenarioValid = true;
                foreach (var scenarioGame in scenarioGames.Values)
                {
                    //Find who the scenario used as the winner for that game
                    var winner = scenario.Scenario.FirstOrDefault(s => s.Equals(scenarioGame.HomeTeam, _scoic) || s.Equals(scenarioGame.AwayTeam, _scoic));
                    //If the winner is not found then this scenario is invalid
                    if (string.IsNullOrEmpty(winner))
                    {
                        isScenarioValid = false;
                        break;
                    }

                    sheet.Cells[row, col++].Value = winner;
                }

                //If the scenario is valid then print the sorted ranked teams
                //If it is not valid then nothing is printed
                if (isScenarioValid)
                {

                    //Print the rankings horizontally
                    var sortedScenarioRankings = from teamRating in scenario.RatingDetails
                                                 orderby teamRating.Value.Rating descending
                                                 select teamRating.Key;
                    foreach (var team in sortedScenarioRankings)
                    {
                        sheet.Cells[row, col++].Value = team;
                    }
                }

                //Reset the column to the start and increment the row
                col = 1;
                row++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }

        #endregion

        #region private utility methods

        /// <summary>
        /// Tries to open a spreadsheet file in Excel.
        /// </summary>
        /// <param name="filePath">The file to open.</param>
        private void TryOpenSpreadsheetFile(string filePath)
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