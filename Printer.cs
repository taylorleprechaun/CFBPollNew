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
        private static readonly string csvFilePath = ConfigurationManager.AppSettings["PollOutputPath_csv"];
        private static readonly string txtFilePath = ConfigurationManager.AppSettings["PollOutputPath_txt"];

        /// <summary>
        /// Prints out the each Team's name, record, and schedule
        /// </summary>
        /// <param name="teamDictionary">The dictionary with all the teams</param>
        public static void PrintSchedules(Dictionary<String, Team> teamDictionary)
        {
            foreach (Team team in teamDictionary.Values)
            {
                Console.Write(team.Name + ": ");
                team.Schedule.PrintRecord();
                Console.WriteLine();
                team.Schedule.PrintSchedule();
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
            team.Schedule.PrintRecord();
            Console.WriteLine();
            Console.WriteLine(team.Conference + " " + team.Division);
            Console.WriteLine(team.Schedule.Strength + " " + team.Schedule.OpponentStrength);
            Console.WriteLine("===========================================");
            team.Schedule.PrintSchedule();
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
            if (File.Exists(csvFilePath))
            {
                File.Delete(csvFilePath);
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
                nextLine += team.Schedule.Wins + ",";
                nextLine += team.Schedule.Losses + ",";
                nextLine += (team.Schedule.Wins/team.Schedule.GamesPlayed).ToString("0.0000") + ",";
                nextLine += team.Schedule.Strength.ToString("0.0000") + ",";
                nextLine += team.Schedule.WeightedStrength.ToString("0.0000") + ",";
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
                File.WriteAllText(csvFilePath, csv.ToString());

                //Increment rank
                rank++;
            }

            //Open the file
            System.Diagnostics.Process.Start(csvFilePath);
        }

        /// <summary>
        /// Prints the poll with formatting
        /// </summary>
        /// <param name="numTeams">Number of teams to print</param>
        /// <param name="teamDictionary">Dictionary of the teams to print</param>
        public static void PrintPollTable(int numTeams, Dictionary<string, Team> teamDictionary)
        {
            //Delete output csv if it exists
            if (File.Exists(txtFilePath))
            {
                File.Delete(txtFilePath);
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
                nextLine += team.Schedule.Wins + "-" + team.Schedule.Losses;
                nextLine += "\n";

                //Append to csv output
                txt.Append(nextLine);

                //Write to output
                File.WriteAllText(txtFilePath, txt.ToString());

                //Increment rank
                rank++;

                //Only print numTeams number of teams
                if (rank > numTeams)
                {
                    break;
                }
            }

            //Open the file
            System.Diagnostics.Process.Start(txtFilePath);
        }
    }
}
