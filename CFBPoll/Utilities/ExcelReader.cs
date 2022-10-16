using CFBPoll.Enums;
using CFBPoll.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace CFBPoll.Utilities
{
    class ExcelReader
    {
        /// <summary>
        /// Assigns teams Stats objects for each team that has stats in the excel files
        /// </summary>
        /// <param name="season">The season year</param>
        /// <param name="week">The week of the season</param>
        /// <param name="teamDictionary">The dictionary object with all our teams</param>
        public static void GetStats(string season, string week, Dictionary<String, Team> teamDictionary)
        {
            //Create the file paths for the stat xlsx files
            string statsPath = ConfigurationManager.AppSettings["StatsPath"];
            string filePathOffense = statsPath + season + "\\TeamO" + " - " + season + " - " + week + ".xlsx";
            string filePathDefense = statsPath + season + "\\TeamD" + " - " + season + " - " + week + ".xlsx";

            if (week.Equals("NCG", StringComparison.OrdinalIgnoreCase))
            {
                var files = Directory.GetFiles(statsPath + season);
                filePathOffense = files.LastOrDefault(f => f.Contains("NCG") && f.Contains("TeamO"));
                filePathDefense = files.LastOrDefault(f => f.Contains("NCG") && f.Contains("TeamD"));
            }

            //Get the tables from the excel file 
            var offenseTable = GetTableFromExcelFile(filePathOffense);
            var defenseTable = GetTableFromExcelFile(filePathDefense);

            //Assign Stat objects to the teams in the dictionary
            CreateStats(offenseTable, "offense", teamDictionary);
            CreateStats(defenseTable, "defense", teamDictionary);
        }

        /// <summary>
        /// Assigns the stat object the teams in the dictionary
        /// </summary>
        /// <param name="statTable">The table with the offensive/defensive stats</param>
        /// <param name="type">Holds whether the statTable is offense or defense</param>
        /// <param name="teamDictionary">The dictionary object with all our teams</param>
        private static void CreateStats(IXLTable statTable, string type, Dictionary<String, Team> teamDictionary)
        {
            //For reach row in the stat table
            foreach (var row in statTable.Rows())
            {
                //Check if the team name in the row is "School" (first row of the table) or null/empty
                var teamName = NameCorrection.NameCorrector(row.Cell(2).Value.ToString());
                if (teamName.Equals("School") || string.IsNullOrEmpty(teamName))
                {
                    continue;
                }

                //If the dictionary has the team name from the row
                if (teamDictionary.ContainsKey(teamName))
                {
                    //Update the offense/defense stats for that team in the dictionary
                    if (type.Equals("offense"))
                    {
                        teamDictionary[teamName].OffenseStats = new Stats(row);
                    }
                    else if (type.Equals("defense"))
                    {
                        teamDictionary[teamName].DefenseStats = new Stats(row);
                    }                    
                }
            }
        }

        /// <summary>
        /// Creates Schedule objects for each team that has games played
        /// </summary>
        /// <param name="season">The season year</param>
        /// <param name="week">The week of the season</param>
        /// <param name="teamDictionary">The dictionary object with all our teams</param>
        public static void GetSchedules(string season, string week, Dictionary<String, Team> teamDictionary)
        {
            string scoresPath = ConfigurationManager.AppSettings["ScoresPath"];
            string filePathScores = scoresPath + season + "\\" + season + " - " + week + ".xlsx";

            if (week.Equals("NCG", StringComparison.OrdinalIgnoreCase))
            {
                var files = Directory.GetFiles(scoresPath + season);
                filePathScores = files.LastOrDefault(f => f.Contains("NCG"));
            }

            var scoresTable = GetTableFromExcelFile(filePathScores);

            foreach (var row in scoresTable.Rows())
            {
                Team team1, team2;

                //Get the team names
                var team1Name = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(row.Cell(5).Value.ToString()));
                var team2Name = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(row.Cell(8).Value.ToString()));
                
                //If the team names are Winner and Loser then skip because this is the header row
                if (team1Name.Equals("Winner") && team2Name.Equals("Loser"))
                {
                    continue;
                }

                //Get the week
                int gameWeek;
                if (int.TryParse(row.Cell(2).Value.ToString(), out var wk))
                    gameWeek = wk;
                else
                    continue;

                //Get the location
                Location team1Location, team2Location;
                var locationValue = row.Cell(7).Value.ToString();
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
                int team1Score, team2Score;
                int.TryParse(row.Cell(6).Value.ToString(), out team1Score);
                int.TryParse(row.Cell(9).Value.ToString(), out team2Score);

                //If the team exists then initialize it, otherwise make it an FCS filler team
                if (teamDictionary.ContainsKey(team1Name))
                {
                    team1 = teamDictionary[team1Name];
                }
                else
                {
                    team1 = new Team("FCS-" + team1Name);
                }               
                //Same deal here
                if (teamDictionary.ContainsKey(team2Name))
                {
                    team2 = teamDictionary[team2Name];
                }
                else
                {
                    team2 = new Team("FCS-" + team2Name);
                }

                //Create the games for the winning and losing teams to add to their Schedule
                Game team1Game = new Game(team1, team2, team1Score, team2Score, gameWeek, team1Location);
                Game team2Game = new Game(team2, team1, team2Score, team1Score, gameWeek, team2Location);

                //If the score is 0 - 0 add the game to the future schedule
                if (team1Score == 0 && team2Score == 0)
                {
                    team1.FutureSchedule.Add(team1Game);
                    team2.FutureSchedule.Add(team2Game);
                }
                //If the score isn't 0 - 0 add the game to the past schedule
                else
                {
                    team1.PastSchedule.Add(team1Game);
                    team2.PastSchedule.Add(team2Game);
                }
            }
        }

        //Gets the excel table object from the Excel file
        private static IXLTable GetTableFromExcelFile(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var excelFile = new XLWorkbook(fileStream);
            var excelSheet = excelFile.Worksheets.Worksheet("Sheet2");
            return excelSheet.Table(0);
        }

        /// <summary>
        /// Load team scores into seasons list
        /// </summary>
        /// <param name="seasons">The list of seasons to load the data into</param>
        /// <returns>The provided list of seasons with scores data loaded</returns>
        public static void LoadTeamScores(IEnumerable<Season> seasons)
        {
            //Get array of files containing team score information
            var basePath = ConfigurationManager.AppSettings["ScoresPath"];
            var scoresDirectories = Directory.GetDirectories(basePath);

            //Loop through each season of scores information
            foreach (var scoresFolder in scoresDirectories)
            {
                var scoresFiles = Directory.GetFiles(scoresFolder);
                
                //Sort by descending and get the first file name to get the newest one
                var scoresFile = scoresFiles.OrderByDescending(f => f).FirstOrDefault();

                //Get the season number
                int season = int.Parse(scoresFile.Split('\\').LastOrDefault().Substring(0,4));

                //Get the scores table from excel
                var scoresTable = GetTableFromExcelFile(scoresFile);
                
                //Loop through the score rows
                foreach (var row in scoresTable.Rows())
                {
                    //Create games from score row
                    GetGamesFromScoreRow(row, out var game1, out var game2);
                    
                    //Update team schedules
                    seasons.Where(s => s.Year == season)?.FirstOrDefault()?.
                        Teams?.Where(t => t.Name.Equals(game1?.TeamName, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault()?.
                            Schedule?.Add(game1);
                    seasons.Where(s => s.Year == season)?.FirstOrDefault()?.
                        Teams?.Where(t => t.Name.Equals(game2?.TeamName, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault()?.
                            Schedule?.Add(game2);
                }
            }
        }

        /// <summary>
        /// Gets game from the provided Excel row containing score information
        /// </summary>
        /// <param name="scoreRow">The Excel row containg score information</param>
        /// <param name="game1">Output variable containing the Game to assign to the first team</param>
        /// <param name="game2">Output variable containing the Game to assign to the second team</param>
        private static void GetGamesFromScoreRow(IXLRangeRow scoreRow, out Game game1, out Game game2)
        {
            //Initialize return game variables
            game1 = null;
            game2 = null;

            //Get the team names
            var team1Name = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(scoreRow.Cell(5).Value.ToString()));
            var team2Name = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(scoreRow.Cell(8).Value.ToString()));

            //If the team names are Winner/Loser then this is row 1 and we skip it
            if (team1Name.Equals("Winner") && team2Name.Equals("Loser"))
                return; 

            //Get the week
            var gameWeek = int.Parse(scoreRow.Cell(2).Value.ToString());

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

            //Parse the scores
            int.TryParse(scoreRow.Cell(6).Value.ToString(), out int team1Score);
            int.TryParse(scoreRow.Cell(9).Value.ToString(), out int team2Score);

            //Create the games using the names, scores, week, and location
            //These are output parameters which will get used in the calling method
            game1 = new Game(team1Name, team2Name, team1Score, team2Score, gameWeek, team1Location);
            game2 = new Game(team2Name, team1Name, team2Score, team1Score, gameWeek, team2Location);
        }

        public static void LoadTeamStats(IEnumerable<Season> seasons)
        {
            //Create the file paths for the stat xlsx files
            string basePath = ConfigurationManager.AppSettings["StatsPath"];
            var statsDirectories = Directory.GetDirectories(basePath);

            //Loop through each season of scores information
            foreach (var statsFolder in statsDirectories)
            {
                //Get the season number
                int season = int.Parse(statsFolder.Split('\\').LastOrDefault().Substring(0, 4));

                //Loop through all the stats files
                var statsFiles = Directory.GetFiles(statsFolder);
                foreach (var statsFile in statsFiles)
                {
                    var week = statsFile.Split('\\').LastOrDefault().Split('.').FirstOrDefault().Split('-').LastOrDefault().Trim();

                    //If the file name contains TeamD then it is defensive stats
                    if (statsFile.Contains("TeamD"))
                    {
                        var defenseTable = GetTableFromExcelFile(statsFile);
                        CreateStats(defenseTable, "defense", season, week, seasons);
                    }
                    //If the file name contains TeamO then it is offensive stats
                    else
                    {
                        var offenseTable = GetTableFromExcelFile(statsFile);
                        CreateStats(offenseTable, "offense", season, week, seasons);
                    }
                }    
            }
        }

        /// <summary>
        /// Assigns the stat object the teams in the dictionary
        /// </summary>
        /// <param name="statTable">The table with the offensive/defensive stats</param>
        /// <param name="type">Holds whether the statTable is offense or defense</param>
        /// <param name="season">The season the stats belong to</param>
        /// <param name="week">The week of the stats</param>
        /// <param name="seasons">All of the seasons</param>
        private static void CreateStats(IXLTable statTable, string type, int season, string week, IEnumerable<Season> seasons)
        {
            //For reach row in the stat table
            foreach (var row in statTable.Rows())
            {
                //Check if the team name in the row is "School" (first row of the table) or null/empty
                var teamName = NameCorrection.NameCorrector(row.Cell(2).Value.ToString());
                if (teamName.Equals("School") || string.IsNullOrEmpty(teamName)) continue;

                //Add offense/defense stats to the teams
                if (type.Equals("offense", StringComparison.OrdinalIgnoreCase))
                {
                    seasons.Where(s => s.Year == season)?.FirstOrDefault()?.
                        Teams?.Where(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault()?.
                            OffStats.Add(week, new Stats(row));
                }
                else if (type.Equals("defense", StringComparison.OrdinalIgnoreCase))
                {
                    seasons.Where(s => s.Year == season)?.FirstOrDefault()?.
                        Teams?.Where(t => t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault()?.
                            DefStats.Add(week, new Stats(row));
                }
            }
        }
    }
}
