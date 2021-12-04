using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace CFBPollNew
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
                int gameWeek = int.Parse(row.Cell(2).Value.ToString());

                //Get the location
                LocationEnum team1Location, team2Location;
                var locationValue = row.Cell(7).Value.ToString();
                if (locationValue.Equals("@"))
                {
                    team1Location = LocationEnum.Road;
                    team2Location = LocationEnum.Home;
                }
                else if (locationValue.Equals("N"))
                {
                    team1Location = LocationEnum.Neutral;
                    team2Location = LocationEnum.Neutral;
                }
                else
                {
                    team1Location = LocationEnum.Home;
                    team2Location = LocationEnum.Road;
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
    }
}
