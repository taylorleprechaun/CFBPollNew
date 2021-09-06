using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CFBPollNew
{
    class TeamReader
    {

        /// <summary>
        /// Creates the dictionary with all the teams from the txt file containing all the teams
        /// </summary>
        /// <param name="season">The season year</param>
        public static Dictionary<String, Team> GetTeamsFromFile(string season)
        {
            Dictionary<String, Team> teamDictionary = new Dictionary<String, Team>();

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
    }
}
