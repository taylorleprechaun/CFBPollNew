using CFBPoll.Models;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CFBPoll.Utilities
{
    class TeamReader
    {
        /// <summary>
        /// Creates the dictionary with all the teams from the txt file containing all the teams
        /// </summary>
        /// <param name="season">The season year</param>
        public static Dictionary<string, Team> GetTeamsFromFile(string season)
        {
            Dictionary<string, Team> teamDictionary = new Dictionary<string, Team>();

            //Get the array of teams from the txt file
            string teamsPath = ConfigurationManager.AppSettings["TeamsPath"];
            string filePath = teamsPath + "FBS-CONF-" + season + ".txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);

            //Loop through the array
            foreach (var line in lines)
            {
                //Split each line at | into an array
                string[] lineInfo = line.Split('|');

                //Initialize new team with the Name, Conference, Division, and empty stats
                Team newTeam = new Team(NameCorrection.NameCorrector(lineInfo[0]), lineInfo[1], lineInfo[2])
                {
                    OffenseStats = new Stats("blank"),
                    DefenseStats = new Stats("blank")
                };

                //Add the new team to the dictionary
                teamDictionary.Add(NameCorrection.NameCorrector(lineInfo[0]), newTeam);
            }

            return teamDictionary;
        }

        /// <summary>
        /// Creates a list of Seasons containing Teams for each season
        /// </summary>
        /// <returns>A list of Seasons containing Teams for each season</returns>
        public static IEnumerable<Season> LoadSeasons()
        {
            //Create list of teams to return
            var seasons = new List<Season>();

            //Get an array of files containing team information
            var basePath = ConfigurationManager.AppSettings["TeamsPath"];
            var teamFiles = Directory.GetFiles(basePath);

            //Loop through lists of teams and construct Seasons
            foreach (var teamFile in teamFiles)
            {
                //Create list of teams to add and parse the year from the file name
                var teams = new List<Team>();
                var year = int.Parse(teamFile.Split('\\').Last().Split('-').Last().Substring(0,4));
                
                //Loop through the text file
                string[] lines = File.ReadAllLines(teamFile);
                foreach (var line in lines)
                {
                    //Split each line at | into an array and get the corrected name, conference, and division
                    string[] lineInfo = line.Split('|');
                    var correctedName = NameCorrection.NameCorrector(lineInfo[0]);
                    var conference = lineInfo[1];
                    var division = lineInfo[2];
                    
                    //Add the team
                    teams.Add(new Team(correctedName, conference, division));
                }

                //Create a new season with these teams
                seasons.Add(new Season(teams, year));
            }

            //Return the seasons
            return seasons;
        }
    }
}
