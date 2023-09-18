using CFBPollDTOs;
using Microsoft.Extensions.Configuration;

namespace CFBPoll.Data.Modules
{
    public class ConsoleDataModule
    {
        private readonly string _filesPath;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public ConsoleDataModule(IConfiguration config)
        {
            _filesPath = config.GetSection("AppSettings:FilesPath").Value ?? string.Empty;
        }

        #region public methods

        /// <summary>
        /// Checks if the user would like to exit the program
        /// </summary>
        /// <returns>True if yes, False if no</returns>
        public bool DoExit()
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

        public Game GetGameToPredict(IDictionary<string, Team> teams, int season)
        {
            //Get user input for the team name until it is valid and then set it
            string awayTeamName = GetTeam("Road");
            while (!teams.ContainsKey(awayTeamName))
            {
                Console.WriteLine("Invalid team name");
                awayTeamName = GetTeam("Road");
            }

            //Get user input for the team name until it is valid and then set it
            string homeTeamName = GetTeam("Home");
            while (!teams.ContainsKey(homeTeamName))
            {
                Console.WriteLine("Invalid team name");
                homeTeamName = GetTeam("Home");
            }

            //Create an empty game to predict
            return new Game(homeTeamName, awayTeamName, 0, 0, season, 0, false, false);
        }

        /// <summary>
        /// Gets the run type for the program
        /// </summary>
        /// <returns>The run type for the program</returns>
        public string GetRunType()
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
        /// Gets the user input for the season to run the program for
        /// </summary>
        /// <returns>The string year entered by the user</returns>
        public int GetSeason()
        {
            Console.WriteLine("Select a season:");
            DisplayAvailableSeasons();
            Console.WriteLine();
            if (int.TryParse(GetInput(), out var season))
                return season;
            else
                return DateTime.Now.Year;
        }

        /// <summary>
        /// Gets the user input for the home/road team
        /// </summary>
        /// <param name="roadHome">A string to fill in the user prompt (home, road)</param>
        /// <returns>The user input</returns>
        private string GetTeam(string roadHome)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the " + roadHome + " team");
            return GetInput();
        }

        /// <summary>
        /// Gets the user input for the week of the season to run the program
        /// </summary>
        /// <returns>The string week entered by the user</returns>
        public string GetWeek(int season)
        {
            Console.WriteLine();
            Console.WriteLine("Select a Week:");
            DisplayAvailableWeeks(season);
            Console.WriteLine();
            return GetInput();
        }

        /// <summary>
        /// Gets the user input for if they would like to predict another game
        /// </summary>
        /// <returns>True if they do, False if they don't</returns>
        public bool PredictAgain()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Predict Again? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", _scoic))
                    return true;
                else if (input.Equals("N", _scoic))
                    return false;
                else
                    Console.WriteLine("Invalid input");
            }
        }



        /// <summary>
        /// Prints the result of a specific game
        /// </summary>
        /// <param name="game">The game to print</param>
        public void PrintGame(Game game)
        {
            //Print result
            Console.WriteLine("\nResult:");
            Console.WriteLine($"{game.AwayTeam} - {Math.Round(game.AwayPoints, 2)}");
            Console.WriteLine($"{game.HomeTeam} - {Math.Round(game.HomePoints, 2)}");
        }



        /// <summary>
        /// Prints an enumerable of options for the user formatted in lines of 7 items with a tab character between each
        /// </summary>
        /// <param name="options">The options to print</param>
        public void PrintUserOptions(IEnumerable<string> options)
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

        #endregion

        #region private methods

        /// <summary>
        /// Displays the available seasons to select for the program
        /// </summary>
        private void DisplayAvailableSeasons()
        {
            var seasons = new List<string>();
            string[] dirs = Directory.GetDirectories(_filesPath);
            foreach (var dir in dirs)
            {
                //The add the last 4 characters (the year) of the path to a List
                seasons.Add(dir[^4..]);
            }
            //Print the options
            PrintUserOptions(seasons);
        }

        /// <summary>
        /// Displays the available weeks to select for the season
        /// </summary>
        /// <param name="season">The season to display the available weeks for</param>
        private void DisplayAvailableWeeks(int season)
        {
            var weeks = new List<string>();
            var newFilePath = $"{_filesPath}{season}\\";
            var dirs = Directory.GetFiles(newFilePath);
            foreach (var dir in dirs)
            {
                //Get rid of the file path in the string, substring off part of the file name to the end of it, then get rid of the file extension
                weeks.Add(dir.Replace(newFilePath, "")[7..].Replace(".xlsx", ""));
            }
            //Print the options
            PrintUserOptions(weeks);
        }

        /// <summary>
        /// Reads the user input from the console
        /// </summary>
        /// <returns>A string containing the user input</returns>
        private string GetInput()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        #endregion
    }
}
