using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace CFBPoll.Utilities
{
    class UserInputReader
    {
        /// <summary>
        /// Gets the user input for what we're running
        /// </summary>
        /// <returns></returns>
        public static string GetRunType()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the number for what you would like to run:");
                Console.WriteLine("1 - Run Poll");
                Console.WriteLine("2 - Run Predictions");
                Console.WriteLine("3 - Predict Individual Games");
                var input = GetInput();

                if (!input.Equals("1") && !input.Equals("2") && !input.Equals("3"))
                    Console.WriteLine("Invalid input");
                else
                    return input;
            }
        }

        /// <summary>
        /// Gets the user input for the season to run the poll on
        /// </summary>
        /// <returns>A string containing the year</returns>
        public static string GetUserInputSeason()
        {
            Console.WriteLine("Select a season:");
            GetSeasonsAvailable();
            Console.WriteLine();
            return GetInput();
        }

        /// <summary>
        /// Gets the list of folders in the FilesPath config key and calls a method to print them out
        /// </summary>
        private static void GetSeasonsAvailable()
        {
            List<string> seasons = new List<string>();
            string filePath = ConfigurationManager.AppSettings["FilesPath"];
            string[] dirs = Directory.GetDirectories(filePath);
            foreach (var dir in dirs)
            {
                //The add the last 4 characters (the year) of the path to a List
                seasons.Add(dir.Substring(dir.Length-4));
            }
            //Print the options
            Printer.PrintUserOptions(seasons);
        }

        /// <summary>
        /// Gets the user input for the week to run the poll on using the season they selected
        /// </summary>
        /// <param name="season"></param>
        /// <returns>A string containing the week</returns>
        public static string GetUserInputWeek(string season)
        {
            Console.WriteLine();
            Console.WriteLine("Select a Week:");
            GetWeeksAvailable(season);
            Console.WriteLine();
            return GetInput();
        }

        /// <summary>
        /// Gets the user input for the team to use in the prediction
        /// </summary>
        /// <param name="prompt">Passed in as Home/Away</param>
        /// <returns></returns>
        public static string GetTeam(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the " + prompt + " team");
            return GetInput();
        }

        /// <summary>
        /// Get the user input for if they want to run another prediction
        /// </summary>
        /// <returns>True if yes, False if no</returns>
        public static bool PredictAgain()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Predict Again? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    return true;
                else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                    return false;
                else
                    Console.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Does the user want to exit
        /// </summary>
        /// <returns>True if yes, False if no</returns>
        public static bool Exit()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to exit? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    return true;
                else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                    return false;
                else
                    Console.WriteLine("Invalid input");
            }
        }


        /// <summary>
        /// Gets the available weeks from the given season and calls a method to print them out
        /// </summary>
        /// <param name="season">The season</param>
        private static void GetWeeksAvailable(string season)
        {
            List<string> weeks = new List<string>();
            string filePath = ConfigurationManager.AppSettings["FilesPath"] + season + "\\";
            string[] dirs = Directory.GetFiles(filePath);
            foreach (var dir in dirs)
            {
                //Get rid of the file path in the string, substring off part of the file name to the end of it, then get rid of the file extension
                weeks.Add(dir.Replace(filePath, "").Substring(7).Replace(".xlsx",""));
            }
            //Print the options
            Printer.PrintUserOptions(weeks);
        }

        /// <summary>
        /// Reads the user input from the console
        /// </summary>
        /// <returns>A string containing the user input</returns>
        private static string GetInput()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
