using CFBPoll.DTOs;
using CFBPoll.DTOs.Rating;
using CFBPoll.Utilities;
using System.Diagnostics;
using System.Text;

namespace CFBPoll.System.Data.SpreadsheetData
{
    public class SpreadsheetData
    {
        private readonly string _csvPollFilePath;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        
        public SpreadsheetData()
        {
            _csvPollFilePath = ConfigurationHelper.GetConfiguration("PollOutputPath_csv");
        }

        #region public methods

        /// <summary>
        /// Print the poll details to a CSV file.
        /// </summary>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        public void PrintPollDetails(IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            //Delete output file if it exists
            if (File.Exists(_csvPollFilePath))
                File.Delete(_csvPollFilePath);

            var csv = new StringBuilder();

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var sortedSeasons = from teamRating in ratingDetails
                                orderby teamRating.Value.Rating descending
                                select teamRating;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.Rating;
            var rank = 1;


            //CSV header
            var csvHeader = $"Number,Team,Score,Points,Wins,Losses,Percentage,Strength of Scheudule,Weighted,Conference,Division,{string.Join(",", sortedSeasons.FirstOrDefault().Value.RatingComponents.Keys)}";
            csv.AppendLine(csvHeader);

            //Loop through teams
            foreach (var sortedSeason in sortedSeasons)
            {
                var teamName = sortedSeason.Key;
                var teamSeason = sortedSeason.Value;

                //Add info
                string nextLine = ""
                    + $"{rank},"
                    + $"{teamName},"
                    + $"{teamSeason.Rating:0.0000},"
                    + $"{teamSeason.Rating / topRating:0.0000},"
                    + $"{teamSeason.Wins},"
                    + $"{teamSeason.Losses},"
                    + $"{teamSeason.Wins / Convert.ToDouble(teamSeason.Wins + teamSeason.Losses):0.0000},"
                    + $"{teamSeason.StrengthOfSchedule.Strength:0.0000},"
                    + $"{teamSeason.StrengthOfSchedule.WeightedStrength:0.0000},"
                    + $"{teamInfo[teamName].TeamInfo.Conference},"
                    + $"{teamInfo[teamName].TeamInfo.Division},"
                    + string.Join(",", teamSeason.RatingComponents.Values.Select(v => v.ToString("0.00")))
                    + $"\n";
                    
                //Append to csv output
                csv.Append(nextLine);

                //Increment rank
                rank++;
            }

            //Write to output
            File.WriteAllText(_csvPollFilePath, csv.ToString());

            //Open the file
            TryOpenCSVFile(_csvPollFilePath);
        }

        /// <summary>
        /// Tries to open a CSV file in Excel.
        /// </summary>
        /// <param name="filePath">The file to open.</param>
        private void TryOpenCSVFile(string filePath)
        {
            try
            {
                Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\EXCEL.exe", filePath);
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to open file: {filePath}.");
            }
        }

        #endregion
    }
}