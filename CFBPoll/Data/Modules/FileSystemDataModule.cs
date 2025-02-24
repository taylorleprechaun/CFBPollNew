using Microsoft.Extensions.Configuration;

namespace CFBPoll.Data.Modules
{
    public class FileSystemDataModule
    {
        private readonly string _filesPath;

        public FileSystemDataModule(IConfiguration config)
        {
            _filesPath = config.GetSection("AppSettings:FilesPath").Value ?? string.Empty;
        }

        #region public methods

        /// <summary>
        /// Gets the available seasons to select for the program
        /// </summary>
        /// <returns>A list of the available seasons</returns>
        public IEnumerable<int> GetSeasons()
        {
            var seasons = new List<int>();
            string[] dirs = Directory.GetDirectories(_filesPath);
            foreach (var dir in dirs)
            {
                //The add the last 4 characters (the year) of the path to a List
                var season = dir[^4..];
                if (int.TryParse(season, out var seasonInt))
                    seasons.Add(seasonInt);
            }

            return seasons;
        }

        /// <summary>
        /// Gets the available weeks to select for the program based on the season
        /// </summary>
        /// <param name="season">The season to get the weeks for</param>
        /// <returns>A list of the available weeks for the season</returns>
        public IEnumerable<int> GetWeeks(int season)
        {
            var weeks = new List<int>();
            var newFilePath = $"{_filesPath}{season}\\";
            var dirs = Directory.GetFiles(newFilePath);
            foreach (var dir in dirs)
            {
                //Get rid of the file path in the string, substring off part of the file name to the end of it, then get rid of the file extension
                var week = dir.Replace(newFilePath, "").Substring(7, 2);
                if (int.TryParse(week, out var weekInt))
                    weeks.Add(weekInt);
            }

            return weeks;
        }

        #endregion
    }
}
