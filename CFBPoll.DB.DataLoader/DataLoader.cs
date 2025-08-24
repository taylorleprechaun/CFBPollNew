using CFBPoll.System.Data.Factories;
using CFBPoll.System.Data.Interfaces;
using CFBPoll.System.Data.Modules;
using CFBPoll.System.Data.Text;
using CFBPoll.System.Utilities;
using CFBPoll.Utilities.ExtensionMethods;

namespace CFBPoll.DB.DataLoader
{
    internal class DataLoader
    {
        private readonly ExcelData _excelData;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly TextData _textData;

        public DataLoader()
        {
            var nameCorrector = new NameCorrector();
            _excelData = new ExcelData(nameCorrector);
            _textData = new TextData(nameCorrector);
        }

        /// <summary>
        /// Run the Data Loader.
        /// </summary>
        public void Run()
        {
            var directory = Path.GetFullPath("./Data");
            var directoryInfo = new DirectoryInfo(directory);
            var files = directoryInfo.GetFilesByExtensions(".xlsx", ".txt");
            if (files == null || !files.Any())
            {
                Console.WriteLine("No Excel files found in the Data directory: " + directory);
                return;
            }

            var filesToProcess = GetOrderedDataLoaderTasks(files);
            foreach (var fileToProcess in filesToProcess)
            {
                try
                {
                    Console.WriteLine("Processing file: " + fileToProcess.Key);
                    fileToProcess.Value.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + fileToProcess.Key + ": " + ex.Message);
                }
            }
        }

        #region private methods

        /// <summary>
        /// Moves the file from the given path into an "Archive" subdirectory.
        /// </summary>
        /// <param name="filePath">The file to archive.</param>
        private void ArchiveFile(string filePath)
        {
            var fileDirectory = Path.GetDirectoryName(filePath);
            if (fileDirectory == null)
                return;

            var archiveDirectory = Path.Combine(fileDirectory, "Archive");
            if (!Directory.Exists(archiveDirectory))
                Directory.CreateDirectory(archiveDirectory);

            var fileName = Path.GetFileName(filePath);
            var archivePath = Path.Combine(archiveDirectory, fileName);

            //Append a timestamp to avoid overwrite
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            archivePath = Path.Combine(archiveDirectory, $"{fileNameWithoutExt}_{timestamp}{ext}");

            File.Move(filePath, archivePath);
        }

        /// <summary>
        /// Returns a dictionary of actions that process each file in the correct order.
        /// Order to sort files:
        /// 1. Team files first (FBS-Conf-{season}.txt)
        /// 2. Statistics files second (TeamO-{season}-{week}.xlsx and TeamD-{season}-{week}.xlsx)
        /// 3. Score files last ({season}-{week}.xlsx)
        /// </summary>
        /// <param name="files">The files to process.</param>
        /// <returns>A dictionary with the name of the file and an to run to process it.</returns>
        private IDictionary<string, Action> GetOrderedDataLoaderTasks(IEnumerable<FileInfo> files)
        {
            //Order the files first
            var orderedFiles = files
                .OrderBy(f =>
                {
                    var name = f.Name;
                    if (name.StartsWith("FBS-Conf", _scoic))
                        return 0; // Team files first
                    if (name.StartsWith("TeamO", _scoic) || name.StartsWith("TeamD", _scoic))
                        return 1; // Statistics files second
                    return 2; // Score files last
                })
                .ThenBy(f => f.Name, StringComparer.OrdinalIgnoreCase);

            //Create a dictionary of actions to process each file
            var actions = new Dictionary<string, Action>();
            foreach (var file in orderedFiles)
            {
                var filePath = file.FullName;
                var fileName = file.Name;
                if (fileName.StartsWith("FBS-Conf", _scoic))
                    actions.Add(filePath, () => ProcessTeamsFile(filePath));
                else if (fileName.StartsWith("TeamO", _scoic) || fileName.StartsWith("TeamD", _scoic))
                    actions.Add(filePath, () => ProcessStatisticsFile(filePath));
                else
                    //TODO: Only process the last score file for a given season
                    //This is because if we process an older week in a season it may overwrite newer data
                    actions.Add(filePath, () => ProcessScoreFile(filePath));
            }
            return actions;
        }

        /// <summary>
        /// Process a file with score information.
        /// </summary>
        /// <param name="file">The file to process.</param>
        private void ProcessScoreFile(string file)
        {
            var fileNameParts = SplitFileName(file, '-');
            
            var season = int.Parse(fileNameParts[0].CleanNumericString()); //0 is the season
            var teamScores = _excelData.GetGames(file);

            var scoresDataProvider = DataFactory.GetDataProvider<IScoresData>();
            var scoresTask = scoresDataProvider.Scores_Insert(season, teamScores);
            Task.WaitAll(scoresTask);
            var result = scoresTask.Result;

            ArchiveFile(file);
        }

        /// <summary>
        /// Process a file with statistics information.
        /// </summary>
        /// <param name="file">The file to process.</param>
        private void ProcessStatisticsFile(string file)
        {
            var fileNameParts = SplitFileName(file, '-');

            var statisticsType = fileNameParts[0].StartsWith("TeamO", _scoic) ? "Offense" : "Defense"; //0 is the type of file
            var season = int.Parse(fileNameParts[1].CleanNumericString()); //1 is the season
            var week = int.Parse(fileNameParts[2].CleanNumericString()); //2 is the week
            var teamStatistics = _excelData.GetStatistics(file);

            var statisticsDataProvider = DataFactory.GetDataProvider<IStatisticsData>();
            var statTask = statisticsDataProvider.Statistics_Insert(statisticsType, season, week, teamStatistics);
            Task.WaitAll(statTask);
            var result = statTask.Result;

            ArchiveFile(file);
        }

        /// <summary>
        /// Process a file with team information.
        /// </summary>
        /// <param name="file">The file to process.</param>
        private void ProcessTeamsFile(string file)
        {
            var fileNameParts = SplitFileName(file, '-');

            var season = int.Parse(fileNameParts[2].CleanNumericString()); //2 is the season
            var teams = _textData.GetTeams(file);

            var teamsDataProvider = DataFactory.GetDataProvider<ITeamsData>();
            var teamsTask = teamsDataProvider.Teams_Insert(season, teams.Values);
            Task.WaitAll(teamsTask);
            var result = teamsTask.Result;

            ArchiveFile(file);
        }

        /// <summary>
        /// Splits the file name into its component parts using a given delimiter.
        /// </summary>
        /// <param name="filePath">The path of file to split the name of.</param>
        /// <param name="delimiter">The delimiter used to split the string.</param>
        /// <returns>An array of strings containing the components of the file name.</returns>
        private string[] SplitFileName(string filePath, char delimiter)
        {
            var fileName = Path.GetFileName(filePath);
            return fileName.Split(delimiter);
        }

        #endregion
    }
}