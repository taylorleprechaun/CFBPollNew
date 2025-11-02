namespace CFBPoll.Utilities.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Cleans a string to contain only numeric characters (0-9).
        /// </summary>
        /// <param name="input">The string to clean.</param>
        /// <returns>A string with only numeric characters (0-9).</returns>
        public static string CleanNumericString(this string input)
        {
            return new string([.. input.Where(char.IsDigit)]);
        }
    }
}
