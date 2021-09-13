using System;
using System.Collections.Generic;

/* TODO:
 * 
 * Implement Rating formula
 * Previous seasons data during first weeks of season weighted by week
 * 4 year recruiting rankings
 * Returning production data
 * 
 */


namespace CFBPollNew
{
    class Program
    {
        private static string week;
        private static string season;
        static void Main(string[] args)
        {
            GetPollInfo();
            //Run the poll for current season
            Dictionary<string, Team> currentSeason = GetData(week, season, false);
            Calculate(currentSeason);

            //Create the team dictionary for the previous season
            Dictionary<string, Team> previousSeason = GetData(week, season, true);

            //Weight the season
            Dictionary<string, Team> weightedSeason = currentSeason;
            if (previousSeason != null)
            {
                //Rate the previous season (since we know it's applicable to do now)
                Calculate(previousSeason);

                //Weight the season
                Rating.WeightSeason(weightedSeason, previousSeason, week);
            }


            Printer.PrintPollTable(weightedSeason);
            Printer.PrintPollDetails(weightedSeason);
            //Printer.PrintSchedules(teamDictionary);
            //Printer.PrintTeam(teamDictionary["Ohio State"]);

            System.Threading.Thread.Sleep(5000000);

        }

        /// <summary>
        /// Get user input for the week and season to run the poll
        /// </summary>
        /// <returns>nothing, just sets the private class variables</returns>
        public static void GetPollInfo()
        {
            //Get the season and week
            season = UserInputReader.GetUserInputSeason();
            week = UserInputReader.GetUserInputWeek(season);
        }

        /// <summary>
        /// Takes user input and uses it to get all the data
        /// </summary>
        /// <param name="week">the week to run the poll for</param>
        /// <param name="season">the season to run the poll for</param>
        /// <param name="previousSeason">run the poll for the previous season</param>
        /// <returns>A dictionary of Teams with their stats and schedule/scores</returns>
        public static Dictionary<string, Team> GetData(string week, string season, bool previousSeason) 
        {
            //If it's the previous season adjust which weeks to run it for
            if (previousSeason)
            {
                //If season is > 2000 we're allowed to run previous season
                if (int.Parse(season) > 2000)
                {
                    season = (int.Parse(season) - 1).ToString();
                }
                else
                {
                    return null;
                }

                //If week is < 5 then we want to mix in old data
                if (int.TryParse(week, out int w) && w < 5)
                {
                    week = "NCG";
                }
                else
                {
                    return null;
                }
            }

            //Generate the teams from the txt file
            Dictionary<string, Team> teamDictionary = TeamReader.GetTeamsFromFile(season);
            //Generate the stats and scores for the teams
            ExcelReader.GetStats(season, week, teamDictionary);
            ExcelReader.GetSchedules(season, week, teamDictionary);

            return teamDictionary;
        }

        /// <summary>
        /// Calculates stuff about each team
        /// </summary>
        /// <param name="teamDictionary">A dictionary of Teams</param>
        public static void Calculate(Dictionary<string, Team> teamDictionary)
        {
            //Calculate strength of schedules
            StrengthOfSchedule.GetStrengthOfSchedule(teamDictionary);
            //Calculate rating
            Rating.GetRating(teamDictionary);
        }
    }
}
