using CFBPoll.Calculations;
using CFBPoll.Models;
using CFBPoll.Utilities;
using System.Collections.Generic;

namespace CFBPoll
{
    class Program
    {
        private static string week;
        private static string season;
        static void Main(string[] args)
        {
            //var teams = LoadData();

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

            while (true)
            {
                //What are we running?
                //1 = Print Poll
                //2 = Prediction
                var runType = UserInputReader.GetRunType();
                if (runType.Equals("1"))
                {
                    //Print the poll to markdown table formatted text file
                    Printer.PrintPollTable(weightedSeason);
                    //Print the poll to Excel file with stats and stuff
                    Printer.PrintPollDetails(weightedSeason);

                    //Print the schedule of each team
                    //Printer.PrintSchedules(teamDictionary);
                    //Print some info about a specific team
                    //Printer.PrintTeam(teamDictionary["Ohio State"]);
                }
                else if (runType.Equals("2"))
                {
                    //This part might shit itself if it tries to predict an FCS game... I'll deal with that later
                    //Print predictions to markdown table formatted text file
                    Printer.PrintPredictionsTable(weightedSeason, previousSeason);
                    //Print predictions to Excel file
                    Printer.PrintPredictionsDetails(weightedSeason, previousSeason);
                }
                else if (runType.Equals("3"))
                {
                    //Predict until the user doesn't want to anymore
                    bool predictAgain = true;
                    while (predictAgain)
                    {
                        Predictor.Predict(weightedSeason, previousSeason);
                        predictAgain = UserInputReader.PredictAgain();
                    }
                }
                
                //Leave the window open until the user says they want to exit
                if (UserInputReader.Exit()) break;
            }
        }

        /// <summary>
        /// Loads all-time team data
        /// </summary>
        /// <returns>An enumerable of Season objects containing all team data in those seasons</returns>
        private static IEnumerable<Season> LoadData()
        {
            var seasons = TeamReader.LoadSeasons();
            ExcelReader.LoadTeamScores(seasons);
            ExcelReader.LoadTeamStats(seasons);

            return seasons;
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
