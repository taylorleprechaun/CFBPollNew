using CFBPoll.DTOs.Enums;
using CFBPoll.Utilities;
using CollegeFootballData.Models;
using SysConsole = System.Console;

namespace CFBPoll.Data.Console
{
    public class ConsoleData
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public ConsoleData() { }

        #region public methods

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
                SysConsole.WriteLine("5 - Run Poll Scenarios");
                var input = GetInput();

                if (Enum.TryParse(typeof(RunType), input, out var runType))
                    return (RunType)runType;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Get the games to run scenarios for.
        /// </summary>
        /// <param name="games">The list of possible games to run.</param>
        /// <returns>The user-selected games.</returns>
        public IEnumerable<int?> GetScenarioGamesToRun(IEnumerable<Game> games)
        {
            SysConsole.WriteLine("\nScenario analysis allows you to select games for the next week of the season and run the poll for all combinations of potential winners (max 8).");
            SysConsole.WriteLine("The following games are available for scenario analysis:");

            var gamesDictionary = games?.Where(g => g != null)?.ToDictionary(g => games.ToList().IndexOf(g) + 1, g => g) ?? new Dictionary<int, Game>();
            foreach (var game in gamesDictionary)
            {
                if (string.IsNullOrEmpty(game.Value?.AwayTeam) || string.IsNullOrEmpty(game.Value?.HomeTeam))
                    continue;

                SysConsole.WriteLine($"[{game.Key}] - {game.Value.AwayTeam} vs {game.Value.HomeTeam}");
            }
            SysConsole.WriteLine("\nEnter the numbers of the games you would like to include in the scenario analysis, separated by commas (e.g. 1,3,5):");

            IEnumerable<int> selectedGamesInput = new List<int>();
            bool firstRun = true;
            var input = string.Empty;
            //Capped at 8 games since this would generate 2^8 scenarios and anything more than that a) takes time to run and b) is excessive
            while (firstRun || selectedGamesInput.Count() > 8)
            {
                //Get the user-selected games
                while (string.IsNullOrEmpty(input))
                    input = GetInput();
                
                //Convert the entered string values into a list of int values and then get the corresponding games
                selectedGamesInput = input.Split(',').Select(s => int.TryParse(s, out var i) ? i : -1).Distinct();
                firstRun = false;
            }
            
            return gamesDictionary.Where(g => selectedGamesInput.Contains(g.Key)).Select(g => g.Value.Id).Where(i => i.HasValue);
        }

        /// <summary>
        /// Gets the user input for the season to run the program for.
        /// </summary>
        /// <returns>The string year entered by the user.</returns>
        public int GetSeason()
        {
            SysConsole.WriteLine("\nEnter a season (e.g. 2025):");
            if (int.TryParse(GetInput(), out var season))
                return season;
            else
                return DateTime.Now.Year;
        }

        /// <summary>
        /// Gets the user input for the week of the season to run the program.
        /// </summary>
        /// <returns>The week entered by the user.</returns>
        public int GetWeek()
        {
            SysConsole.WriteLine("\nEnter a Week (e.g. 10):");
            return int.TryParse(GetInput(), out var week) ? week : 0;
        }

        /// <summary>
        /// Gets the user input for if the program is being run for the postseason.
        /// </summary>
        /// <returns>True if it is. False if not.</returns>
        public bool IsPostseason()
        {
            while (true)
            {
                SysConsole.WriteLine("\nIs this for the Postseason? (Y/N)");
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
        /// Checks if the user would like run the program again for a different season or week.
        /// </summary>
        /// <returns>True if yes, False if no.</returns>
        public bool RunAgain()
        {
            while (true)
            {
                SysConsole.WriteLine("\nDo you want to choose a different season or week? (Y/N)");
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
        /// Checks if the user would like to run the current ratings for another run type.
        /// </summary>
        /// <returns>True if yes, False if no.</returns>
        public bool RunAnotherType()
        {
            while (true)
            {
                SysConsole.WriteLine("\nDo you want to pick another run type? (Y/N)");
                var input = GetInput();
                if (input.Equals("Y", _scoic))
                    return true;
                else if (input.Equals("N", _scoic))
                    return false;
                else
                    SysConsole.WriteLine("Invalid input");
            }
        }

        #endregion

        #region private methods

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
