using CFBPoll.DTOs.Enums;
using CFBPoll.Utilities;
using SysConsole = System.Console;

namespace CFBPoll.Data.Console
{
    public class ConsoleData
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public ConsoleData() { }

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
                if (input.Equals("Y", _scoic))
                    return true;
                else if (input.Equals("N", _scoic))
                    return false;
                else
                    SysConsole.WriteLine("Invalid input");
            }
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
            SysConsole.WriteLine("Enter a season (e.g. 2025):");
            SysConsole.WriteLine();
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
            SysConsole.WriteLine();
            return int.TryParse(GetInput(), out var week) ? week : 0;
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
