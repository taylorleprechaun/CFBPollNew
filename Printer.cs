using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CFBPollNew
{
    class Printer
    {
        private static readonly string csvPollFilePath = ConfigurationManager.AppSettings["PollOutputPath_csv"];
        private static readonly string txtPollFilePath = ConfigurationManager.AppSettings["PollOutputPath_txt"];
        private static readonly string csvPredictionsFilePath = ConfigurationManager.AppSettings["PollPredictionsPath_csv"];
        private static readonly string txtPredictionsFilePath = ConfigurationManager.AppSettings["PollPredictionsPath_txt"];

        /// <summary>
        /// Prints out the each Team's name, record, and schedule
        /// </summary>
        /// <param name="teamDictionary">The dictionary with all the teams</param>
        public static void PrintSchedules(Dictionary<String, Team> teamDictionary)
        {
            foreach (Team team in teamDictionary.Values)
            {
                Console.Write(team.Name + ": ");
                team.PastSchedule.PrintRecord();
                Console.WriteLine();
                team.PastSchedule.PrintSchedule();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints information about a single team
        /// </summary>
        /// <param name="team">The team to print the info of</param>
        public static void PrintTeam(Team team)
        {
            Console.WriteLine();
            Console.Write(team.Name + " ");
            team.PastSchedule.PrintRecord();
            Console.WriteLine();
            Console.WriteLine(team.Conference + " " + team.Division);
            Console.WriteLine(team.PastSchedule.Strength + " " + team.PastSchedule.OpponentStrength);
            Console.WriteLine("===========================================");
            team.PastSchedule.PrintSchedule();
            //print other stats, rank, conf, division, etc
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Print out the options for the user to select from from the input options list
        /// </summary>
        /// <param name="options">The list of options to print out</param>
        public static void PrintUserOptions(List<string> options)
        {
            int printNum = 0;
            foreach (var option in options)
            {
                Console.Write(option + "\t");
                printNum++;

                //7 items per line
                if (printNum % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print the poll to a csv file
        /// </summary>
        /// <param name="teamDictionary">A dictionary with all the teams</param>
        public static void PrintPollDetails(Dictionary<string, Team> teamDictionary)
        {
            //Delete output csv if it exists
            if (File.Exists(csvPollFilePath))
            {
                File.Delete(csvPollFilePath);
            }

            //Some setup
            List<Team> teamList = new List<Team>(teamDictionary.Values);
            teamList = teamList.OrderByDescending(t => t.Rating).ToList();
            double topRating = teamList[0].Rating;
            int rank = 1;
            var csv = new StringBuilder();

            //CSV header
            csv.AppendLine("Number,Team,Score,Points,W,L,Pct,SoS,Weighted,Conf,Div,AvgMoV,YF,YA,TO Margin,YPPO,YPPD");            

            //Loop through teams
            foreach (Team team in teamList)
            {
                //Add info
                string nextLine = "";
                nextLine += rank + ",";
                nextLine += team.Name + ",";
                nextLine += team.Rating.ToString("0.0000") + ",";
                nextLine += (team.Rating/topRating).ToString("0.0000") + ",";
                nextLine += team.PastSchedule.Wins + ",";
                nextLine += team.PastSchedule.Losses + ",";
                nextLine += (team.PastSchedule.Wins/team.PastSchedule.Games).ToString("0.0000") + ",";
                nextLine += team.PastSchedule.Strength.ToString("0.0000") + ",";
                nextLine += team.PastSchedule.WeightedStrength.ToString("0.0000") + ",";
                nextLine += team.Conference + ",";
                nextLine += team.Division + ",";
                nextLine += (team.OffenseStats.Points - team.DefenseStats.Points) + ",";
                nextLine += team.OffenseStats.TotalYards + ",";
                nextLine += team.DefenseStats.TotalYards + ",";
                nextLine += (team.OffenseStats.TotalTO - team.DefenseStats.TotalTO) + ",";
                nextLine += (team.OffenseStats.TotalYards / team.OffenseStats.Plays).ToString("0.0000") + ",";
                nextLine += (team.DefenseStats.TotalYards / team.DefenseStats.Plays).ToString("0.0000");
                nextLine += "\n";

                //Append to csv output
                csv.Append(nextLine);

                //Write to output
                File.WriteAllText(csvPollFilePath, csv.ToString());

                //Increment rank
                rank++;
            }

            //Open the file
            System.Diagnostics.Process.Start(csvPollFilePath);
        }

        /// <summary>
        /// Prints the poll with formatting
        /// </summary>
        /// <param name="teamDictionary">Dictionary of the teams to print</param>
        public static void PrintPollTable(Dictionary<string, Team> teamDictionary)
        {
            //Delete output csv if it exists
            if (File.Exists(txtPollFilePath))
            {
                File.Delete(txtPollFilePath);
            }

            //Setup
            List<Team> teamList = new List<Team>(teamDictionary.Values);
            teamList = teamList.OrderByDescending(t => t.Rating).ToList();
            double topRating = teamList[0].Rating;
            int rank = 1;
            var txt = new StringBuilder();

            //Table header
            txt.AppendLine("Rank | Team | Score | Record\n---|---|---|---");
            
            //Loop through teams
            foreach (Team team in teamList)
            {
                //Add info
                string nextLine = "";
                nextLine += rank + " | ";
                nextLine += team.Name + " | ";
                nextLine += (team.Rating / topRating).ToString("0.0000") + " | ";
                nextLine += team.PastSchedule.Wins + "-" + team.PastSchedule.Losses;
                nextLine += "\n";

                //Append to csv output
                txt.Append(nextLine);

                //Write to output
                File.WriteAllText(txtPollFilePath, txt.ToString());

                //Increment rank
                rank++;
            }

            //Open the file
            System.Diagnostics.Process.Start(txtPollFilePath);
        }

        /// <summary>
        /// Print the predictions for all games of the coming week markdown formatted to txt file
        /// </summary>
        /// <param name="teamDictionary">Dictionary of the teams to print</param>
        /// <param name="previousSeasonTeamDictionary">Dictionary of previous season team data</param>
        public static void PrintPredictionsTable(Dictionary<string, Team> teamDictionary, Dictionary<string, Team> previousSeasonTeamDictionary)
        {
            //Delete output csv if it exists
            if (File.Exists(txtPredictionsFilePath))
            {
                File.Delete(txtPredictionsFilePath);
            }

            //Setup
            List<Team> teamList = new List<Team>(teamDictionary.Values);
            var txt = new StringBuilder();
            int weekToPredict = 100;

            //Table header
            txt.AppendLine("Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick\n---| ---| ---| ---| ---| ---| ---| ---");

            //Get the next week of the season that we need to make predictions for
            //Start at 100 set it to the minimum possible from any team's future schedule list
            foreach (Team team in teamList)
            {
                int week = team.FutureSchedule.Games > 0 ? team.FutureSchedule.Schedule[0].Week : 100;
                if (week < weekToPredict)
                {
                    weekToPredict = week;
                }
            }

            //No predictions to be made
            if (weekToPredict == 100) return;

            //List of teams we've already predicted the outcome of
            List<string> predictedTeams = new List<string>();

            //Loop through teams
            foreach (Team team in teamList)
            {
                //Get the first game for the current team's future schedule of the week to predict
                var game = team.FutureSchedule.Schedule.FirstOrDefault(g => g.Week.Equals(weekToPredict));
                //If they have no such game add them to the list of predicted teams and skip
                if (game == null) 
                { 
                    predictedTeams.Add(team.Name); 
                    continue; 
                }
                //Get the opponent
                var opponent = game.Opponent;

                //If we've already predicted these teams then skip
                if (predictedTeams.Contains(team.Name) || predictedTeams.Contains(opponent.Name)) continue;

                //Add the teams to the predicted teams list
                predictedTeams.Add(team.Name);
                predictedTeams.Add(opponent.Name);

                //Predict the winner
                var prediction = Predictor.PredictGame(team, game.Opponent, game.Location, true, previousSeasonTeamDictionary);
                double.TryParse(prediction[0], out var teamScore);
                double.TryParse(prediction[1], out var opponentScore);

                //This comes up for FBS vs FCS
                if (double.IsNaN(teamScore) || double.IsNaN(opponentScore)) continue;
                
                var winner = teamScore > opponentScore;

                //Add info
                string nextLine = "";
                nextLine += game.Location.Equals(LocationEnum.Road) ? team.Name + " - " + opponent.Name + " | " : opponent.Name + " - " + team.Name + " | ";
                nextLine += game.Location.Equals(LocationEnum.Road) ? teamScore + " - " + opponentScore + " | " : opponentScore + " - " + teamScore + " | ";
                nextLine += " | ";
                nextLine += winner ? team.Name + " | " : opponent.Name + " | ";
                nextLine += " | ";
                nextLine += " | ";
                nextLine += " | ";
                nextLine += "\n";

                //Append to csv output
                txt.Append(nextLine);

                //Write to output
                File.WriteAllText(txtPredictionsFilePath, txt.ToString());
            }

            //Open the file
            System.Diagnostics.Process.Start(txtPredictionsFilePath);
        }

        /// <summary>
        /// Print the predictions for all games of the coming week to a csv file
        /// </summary>
        /// <param name="teamDictionary">Dictionary of the teams to print</param>
        /// <param name="previousSeasonTeamDictionary">Dictionary of previous season team data</param>
        public static void PrintPredictionsDetails(Dictionary<string, Team> teamDictionary, Dictionary<string, Team> previousSeasonTeamDictionary)
        {
            //Delete output csv if it exists
            if (File.Exists(csvPredictionsFilePath))
            {
                File.Delete(csvPredictionsFilePath);
            }

            //Setup
            List<Team> teamList = new List<Team>(teamDictionary.Values);
            var csv = new StringBuilder();
            int weekToPredict = 100;

            //Table header
            csv.AppendLine("Away,Location,Home,Away Score,HomeScore,Pick,Spread,O/U");

            //Get the next week of the season that we need to make predictions for
            //Start at 100 set it to the minimum possible from any team's future schedule list
            foreach (Team team in teamList)
            {
                int week = team.FutureSchedule.Games > 0 ? team.FutureSchedule.Schedule[0].Week : 100;
                if (week < weekToPredict)
                {
                    weekToPredict = week;
                }
            }

            //No predictions to be made
            if (weekToPredict == 100) return;

            //List of teams we've already predicted the outcome of
            List<string> predictedTeams = new List<string>();

            //Loop through teams
            foreach (Team team in teamList)
            {
                //Get the first game for the current team's future schedule of the week to predict
                var game = team.FutureSchedule.Schedule.FirstOrDefault(g => g.Week.Equals(weekToPredict));
                //If they have no such game add them to the list of predicted teams and skip
                if (game == null)
                {
                    predictedTeams.Add(team.Name);
                    continue;
                }
                //Get the opponent
                var opponent = game.Opponent;

                //If we've already predicted these teams then skip
                if (predictedTeams.Contains(team.Name) || predictedTeams.Contains(opponent.Name)) continue;

                //Add the teams to the predicted teams list
                predictedTeams.Add(team.Name);
                predictedTeams.Add(opponent.Name);

                //Predict the winner
                var prediction = Predictor.PredictGame(team, game.Opponent, game.Location, false, previousSeasonTeamDictionary);
                double.TryParse(prediction[0], out var teamScore);
                double.TryParse(prediction[1], out var opponentScore);

                //This comes up for FBS vs FCS
                if (double.IsNaN(teamScore) || double.IsNaN(opponentScore)) continue;

                var winner = teamScore > opponentScore;
                var total = teamScore + opponentScore;

                //Add info
                string nextLine = "";
                nextLine += game.Location.Equals(LocationEnum.Road)
                    ? team.Name + "," + game.Location + "," + opponent.Name + "," + teamScore + "," + opponentScore + ","
                    : game.Location.Equals(LocationEnum.Home)
                        ? opponent.Name + "," + game.Location + "," + team.Name + "," + opponentScore + "," + teamScore + ","
                        : game.Location.Equals(LocationEnum.Neutral)
                            ? team.Name + "," + LocationEnum.Neutral + "," + opponent.Name + "," + teamScore + "," + opponentScore + ","
                            : ",,,,,";
                nextLine += winner
                    ? team.Name + "," + team.Name + " " + (teamScore - opponentScore).ToString("0.00") + ","
                    : opponent.Name + "," + opponent.Name + " " + (teamScore - opponentScore).ToString("0.00") + ",";
                nextLine += total;
                nextLine += "\n";

                //Append to csv output
                csv.Append(nextLine);

                //Write to output
                File.WriteAllText(csvPredictionsFilePath, csv.ToString());
            }

            //Open the file
            System.Diagnostics.Process.Start(csvPredictionsFilePath);
        }
    }
}
