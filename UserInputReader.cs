using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPollNew
{
    class UserInputReader
    {
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
