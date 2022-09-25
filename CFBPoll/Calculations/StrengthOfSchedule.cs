using CFBPoll.Models;
using System;
using System.Collections.Generic;

namespace CFBPoll.Calculations
{
    class StrengthOfSchedule
    {
        /// <summary>
        /// Gets the strength of schedule and opponent strength of schedule for a team
        /// </summary>
        /// <param name="teamDictionary">A dictionary with the teams</param>
        public static void GetStrengthOfSchedule(Dictionary<string, Team> teamDictionary)
        {
            //For reach team, calculate the opponent and their strength of schedule
            foreach (var team in teamDictionary.Values)
            {
                double[] opponentStrength = CalculateStrengthOfSchedule(team, teamDictionary, 3);
                team.PastSchedule.OpponentStrength = opponentStrength[1] / opponentStrength[0];

                double[] scheduleStrength = CalculateStrengthOfSchedule(team, teamDictionary, 2);
                team.PastSchedule.Strength = scheduleStrength[1] / scheduleStrength[0];
            }
        }

        /// <summary>
        /// Recursively calculate the strength of schedule to the given depth
        /// </summary>
        /// <param name="team">The team to calculate the strength of schedule for</param>
        /// <param name="teamDictionary">A dicationry with all the teams</param>
        /// <param name="depth">The depth to recursively calculate</param>
        /// <returns>An array of doubles where the first index is the total games and the second index is the total wins</returns>
        private static double[] CalculateStrengthOfSchedule(Team team, Dictionary<string, Team> teamDictionary, int depth)
        {
            //Decrement depth
            depth--;

            //Holds wins and games
            double games = 0;
            double wins = 0;

            //For each game in the schedule
            foreach (Game game in team.PastSchedule.Schedule)
            {
                string opponentName = game.Opponent.Name;
                //If the depth is > 0 then we want to go deeper
                if (depth > 0)
                {
                    //If the team isn't FCS
                    if (!opponentName.StartsWith("FCS-"))
                    {
                        //We have to go deeper
                        double[] info = CalculateStrengthOfSchedule(teamDictionary[opponentName], teamDictionary, depth);
                        //Update the games and wins
                        games += info[0];
                        wins += info[1];
                    }
                }
                //Else update the games and wins based on the result of the game
                else
                {
                    games++;
                    if (game.Result.Equals(ResultEnum.Win))
                    {
                        wins++;
                    }
                }
            }

            //Return total games and wins
            return new double[] { games, wins };            
        }
    }
}
