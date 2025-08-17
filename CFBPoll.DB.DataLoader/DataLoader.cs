using CFBPoll.System.Data.Factories;
using CFBPoll.System.Data.Interfaces;
using CFBPoll.System.Data.Modules;
using CFBPoll.System.Utilities;
using CFBPoll.Utilities.ExtensionMethods;

namespace CFBPoll.DB.DataLoader
{
    internal class DataLoader
    {
        private readonly ExcelData _excelData;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public DataLoader()
        {
            var nameCorrector = new NameCorrector();
            _excelData = new ExcelData(nameCorrector);
        }

        /// <summary>
        /// Run the Data Loader.
        /// </summary>
        public void Run()
        {
            var filePath = Path.GetFullPath("./Data");
            var files = Directory.GetFiles(filePath, "*.xlsx", SearchOption.TopDirectoryOnly);
            if (files == null || !files.Any())
            {
                Console.WriteLine("No Excel files found in the Data directory: " + filePath);
                return;
            }

            foreach (var file in files)
            {
                try
                {
                    Console.WriteLine("Processing file: " + file);
                    
                    var fileName = Path.GetFileName(file);
                    if (fileName.StartsWith("TeamO", _scoic) || fileName.StartsWith("TeamD", _scoic))
                        ProcessStatisticsFile(file);
                    else
                        ProcessScoreFile(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + file + ": " + ex.Message);
                }
            }
        }

        #region private methods

        /// <summary>
        /// Process a file with score information.
        /// </summary>
        /// <param name="file">The file to process.</param>
        private void ProcessScoreFile(string file)
        {
            var fileName = Path.GetFileName(file);
            var fileNameParts = fileName.Split('-');
            
            var season = int.Parse(fileNameParts[0].CleanNumericString()); //0 is the season
            var teamScores = _excelData.GetGames(file);

            var scoresDataProvider = DataFactory.GetDataProvider<IScoresData>();
            var scoresTask = scoresDataProvider.Scores_Insert(season, teamScores);
            Task.WaitAll(scoresTask);
            var result = scoresTask.Result;
        }

        /// <summary>
        /// Process a file with statistics information.
        /// </summary>
        /// <param name="file">The file to process.</param>
        private void ProcessStatisticsFile(string file)
        {
            var fileName = Path.GetFileName(file);
            var fileNameParts = fileName.Split('-');
            
            var statisticsType = fileNameParts[0].StartsWith("TeamO", _scoic) ? "Offense" : "Defense"; //0 is the type of file
            var season = int.Parse(fileNameParts[1].CleanNumericString()); //1 is the season
            var week = int.Parse(fileNameParts[2].CleanNumericString()); //2 is the week
            var teamStatistics = _excelData.GetStatistics(file);

            var statisticsDataProvider = DataFactory.GetDataProvider<IStatisticsData>();
            var statTask = statisticsDataProvider.Statistics_Insert(statisticsType, season, week, teamStatistics);
            Task.WaitAll(statTask);
            var result = statTask.Result;
        }

        #endregion
    }
}