using CFBPoll.DTOs;
using CFBPoll.DTOs.Enums;
using CFBPoll.System.Data.FileSystem;
using CFBPoll.Utilities;
using Microsoft.Extensions.Configuration;
using SysConsole = System.Console;

namespace CFBPoll.Data.Console
{
    public class ConsoleData
    {
        private readonly FileSystemData _fileSystemDataModule;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public ConsoleData(IConfiguration config)
        {
            _fileSystemDataModule = new FileSystemData(config);
        }

        #region public methods

        /// <summary>
        /// Checks if the user would like to exit the program.
        /// </summary>
        /// <returns>True if yes, False if no.</returns>
        public bool DoExit()
        {
            while (true)
            {
                SysConsole.WriteLine("\nDo you want to exit? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    return true;
                else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                    return false;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Gets the game to predict based on user input for the teams and season.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <param name="season">The season.</param>
        /// <returns>A Game that we need to generate a prediction for.</returns>
        public Game GetGameToPredict(IDictionary<string, Team> teams, int season)
        {
            //Get user input for the team name until it is valid and then set it
            string awayTeamName = GetTeam("Road");
            while (!teams.ContainsKey(awayTeamName))
            {
                SysConsole.WriteLine("Invalid team name");
                awayTeamName = GetTeam("Road");
            }

            //Get user input for the team name until it is valid and then set it
            string homeTeamName = GetTeam("Home");
            while (!teams.ContainsKey(homeTeamName))
            {
                SysConsole.WriteLine("Invalid team name");
                homeTeamName = GetTeam("Home");
            }

            //Create an empty game to predict
            return new Game(homeTeamName, awayTeamName, 0, 0, season, 0, false, false, new List<Lines>());
        }

        /// <summary>
        /// Gets the run type for the program.
        /// </summary>
        /// <returns>The run type for the program.</returns>
        public RunType GetRunType()
        {
            while (true)
            {
                SysConsole.WriteLine("\nPlease enter the number for what you would like to run:");
                SysConsole.WriteLine("1 - Run Poll");
                SysConsole.WriteLine("2 - Run Predictions");
                SysConsole.WriteLine("3 - Run Previous Week Prediction Results");
                SysConsole.WriteLine("4 - Predict Individual Games");
                var input = GetInput();

                if (Enum.TryParse(typeof(RunType), input, out var runType))
                    return (RunType)runType;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Gets the user input for the season to run the program for.
        /// </summary>
        /// <returns>The string year entered by the user.</returns>
        public int GetSeason()
        {
            SysConsole.WriteLine("Select a season:");
            DisplayAvailableSeasons();
            SysConsole.WriteLine();
            if (int.TryParse(GetInput(), out var season))
                return season;
            else
                return DateTime.Now.Year;
        }

        /// <summary>
        /// Gets the user input for the home/road team.
        /// </summary>
        /// <param name="roadHome">A string to fill in the user prompt (home, road).</param>
        /// <returns>The user input.</returns>
        private string GetTeam(string roadHome)
        {
            SysConsole.WriteLine("\nEnter the " + roadHome + " team");
            return GetInput();
        }

        /// <summary>
        /// Gets the user input for the week of the season to run the program.
        /// </summary>
        /// <returns>The week entered by the user.</returns>
        public int GetWeek(int season)
        {
            SysConsole.WriteLine("\nSelect a Week:");
            DisplayAvailableWeeks(season);
            SysConsole.WriteLine();
            return int.TryParse(GetInput(), out var week) ? week : 0;
        }

        /// <summary>
        /// Gets the user input for if they would like to predict another game.
        /// </summary>
        /// <returns>True if they do, False if they don't.</returns>
        public bool PredictAgain()
        {
            while (true)
            {
                SysConsole.WriteLine("\nPredict Again? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", _scoic))
                    return true;
                else if (input.Equals("N", _scoic))
                    return false;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Gets the user input for if they would like to print out the details for the given run type.
        /// </summary>
        /// <param name="runType">The run type of the program.</param>
        /// <returns>True if they do, False if they don't.</returns>
        public bool PrintDetails(RunType runType)
        {
            while (true)
            {
                SysConsole.WriteLine($"\nWould you like to see the details for {runType.GetDescription()}? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", _scoic))
                    return true;
                else if (input.Equals("N", _scoic))
                    return false;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Prints the result of a specific game.
        /// </summary>
        /// <param name="game">The game to print.</param>
        public void PrintGame(Game game)
        {
            //Print result
            SysConsole.WriteLine("\nResult:");
            SysConsole.WriteLine($"{game.AwayTeam} - {Math.Round(game.AwayPoints, 2)}");
            SysConsole.WriteLine($"{game.HomeTeam} - {Math.Round(game.HomePoints, 2)}");
        }



        /// <summary>
        /// Prints an enumerable of options for the user formatted in lines of 7 items with a tab character between each.
        /// </summary>
        /// <param name="options">The options to print.</param>
        public void PrintUserOptions(IEnumerable<int> options)
        {
            int printNum = 0;
            foreach (var option in options)
            {
                SysConsole.Write(option + "\t");
                printNum++;

                //7 items per line
                if (printNum % 7 == 0)
                {
                    SysConsole.WriteLine();
                }
            }
            SysConsole.WriteLine();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Displays the available seasons to select for the program.
        /// </summary>
        private void DisplayAvailableSeasons()
        {
            var seasons = _fileSystemDataModule.GetSeasons();
            //Print the options
            PrintUserOptions(seasons);
        }

        /// <summary>
        /// Displays the available weeks to select for the season.
        /// </summary>
        /// <param name="season">The season to display the available weeks for.</param>
        private void DisplayAvailableWeeks(int season)
        {
            var weeks = _fileSystemDataModule.GetWeeks(season);
            //Print the options
            PrintUserOptions(weeks);
        }

        /// <summary>
        /// Reads the user input from the console.
        /// </summary>
        /// <returns>A string containing the user input.</returns>
        private string GetInput()
        {
            SysConsole.Write("> ");
            return SysConsole.ReadLine();
        }

        #endregion
    }
}
