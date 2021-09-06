using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;

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
                Team winningTeam, losingTeam;

                //Get the team names
                var winningTeamName = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(row.Cell(5).Value.ToString()));
                var losingTeamName = NameCorrection.NameCorrector(NameCorrection.NameCorrectorScores(row.Cell(8).Value.ToString()));
                
                //If the team names are Winner and Loser then skip because this is the header row
                if (winningTeamName.Equals("Winner") && losingTeamName.Equals("Loser"))
                {
                    continue;
                }

                //Get scores
                var winningTeamScore = int.Parse(row.Cell(6).Value.ToString());
                var losingTeamScore = int.Parse(row.Cell(9).Value.ToString());

                //If the team exists then initialize it, otherwise make it an FCS filler team
                if (teamDictionary.ContainsKey(winningTeamName))
                {
                    winningTeam = teamDictionary[winningTeamName];
                }
                else
                {
                    winningTeam = new Team("FCS-" + winningTeamName);
                }
                
                //Same deal here
                if (teamDictionary.ContainsKey(losingTeamName))
                {
                    losingTeam = teamDictionary[losingTeamName];
                }
                else
                {
                    losingTeam = new Team("FCS-" + losingTeamName);
                }

                //Create the games for the winning and losing teams to add to their Schedule
                Game winningTeamGame = new Game(winningTeam, losingTeam, winningTeamScore, losingTeamScore);
                Game losingTeamGame = new Game(losingTeam, winningTeam, losingTeamScore, winningTeamScore);

                //Add the Game to the both teams' Schedules
                winningTeam.Schedule.Add(winningTeamGame);
                losingTeam.Schedule.Add(losingTeamGame);
            }
        }

        //Gets the excel table object from the Excel file
        private static IXLTable GetTableFromExcelFile(string filePath)
        {
            var excelFile = new XLWorkbook(filePath);
            var excelSheet = excelFile.Worksheets.Worksheet("Sheet2");
            return excelSheet.Table(0);
        }
    }
}
