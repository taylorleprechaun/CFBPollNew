using CFBPoll.DTOs;
using CFBPoll.DTOs.Rating;
using CFBPoll.Utilities;
using OfficeOpenXml;
using System.Diagnostics;

namespace CFBPoll.System.Data.SpreadsheetData
{
    public class SpreadsheetData
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _xlsxPollFilePath;
        
        public SpreadsheetData()
        {
            _xlsxPollFilePath = ConfigurationHelper.GetConfiguration("PollOutputPath_xlsx");
        }

        #region public methods

        /// <summary>
        /// Print the poll details to a workbook file.
        /// </summary>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        public void PrintPollDetails(IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            //Delete output file if it exists
            if (File.Exists(_xlsxPollFilePath))
                File.Delete(_xlsxPollFilePath);

            ExcelPackage.License.SetNonCommercialPersonal("Taylor Steinberg");
            using (var workbook = new ExcelPackage(_xlsxPollFilePath))
            {
                BuildRatingDetails(workbook, teamInfo, ratingDetails);
                BuildConferenceDetails(workbook, teamInfo, ratingDetails);

                var newFile = new FileInfo(_xlsxPollFilePath);
                workbook.SaveAs(_xlsxPollFilePath);
            }

            TryOpenSpreadsheetFile(_xlsxPollFilePath);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Build the Conference Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Conference Details tab to.</param>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        private void BuildConferenceDetails(ExcelPackage workbook, IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Conference Details");
            var conferences = teamInfo.Values.Select(t => t.TeamInfo.Conference).Distinct().OrderBy(c => c);

            //Set the worksheet headers
            var headers = new List<string>
            {
                "Conference", "Number of Teams",
                "Highest Rank", "Lowest Rank", "Average Rank",
                "Highest Rating", "Lowest Rating", "Average Rating",
                "Highest Weighted SoS", "Lowest Weighted SoS", "Average Weighted SoS",
            };
            int col = 1;
            foreach (var header in headers)
            {
                sheet.Cells[1, col++].Value = header;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            var ratingDetailsKeys = ratingDetails.Keys.ToList();
            foreach (var conference in conferences)
            {
                var conferenceTeams = teamInfo.Values.Where(t => t?.TeamInfo?.Conference?.Equals(conference, _scoic) == true).Select(t => t.TeamInfo.School);
                if (conferenceTeams == null || !conferenceTeams.Any())
                    continue;

                var conferenceRatings = ratingDetails.Where(r => conferenceTeams.Contains(r.Key)).OrderByDescending(r => r.Value.Rating);

                //Excel formulas for stats rather than doing the calculations in code
                //Conference Name
                sheet.Cells[row, col++].Value = conference;
                //Number of Teams
                sheet.Cells[row, col++].Formula = $"COUNTIFS('Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Highest Rank (lowest number)
                sheet.Cells[row, col++].Formula = $"MINIFS('Rating Details'!$A:$A,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Lowest Rank (highest number)
                sheet.Cells[row, col++].Formula = $"MAXIFS('Rating Details'!$A:$A,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Average Rank
                sheet.Cells[row, col].Style.Numberformat.Format = "0.00";
                sheet.Cells[row, col++].Formula = $"AVERAGEIFS('Rating Details'!$A:$A,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Highest Rating (largest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"MAXIFS('Rating Details'!$C:$C,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Lowest Rating (smallest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"MINIFS('Rating Details'!$C:$C,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Average Rating
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"AVERAGEIFS('Rating Details'!$C:$C,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Highest Weighted SoS (largest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"MAXIFS('Rating Details'!$I:$I,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Lowest Weighted SoS (smallest number)
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"MINIFS('Rating Details'!$I:$I,'Rating Details'!$J:$J,'Conference Details'!$A{row})";
                //Average Weighted SoS
                sheet.Cells[row, col].Style.Numberformat.Format = "0.0000";
                sheet.Cells[row, col++].Formula = $"AVERAGEIFS('Rating Details'!$I:$I,'Rating Details'!$J:$J,'Conference Details'!$A{row})";

                //Reset the column to the start and increment the row
                col = 1;
                row++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }

        /// <summary>
        /// Build the Rating Details tab of the workbook.
        /// </summary>
        /// <param name="workbook">The workbook to add the Rating Details tab to.</param>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        private void BuildRatingDetails(ExcelPackage workbook, IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            var sheet = workbook.Workbook.Worksheets.Add("Rating Details");

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var sortedTeamRatings = from teamRating in ratingDetails
                                orderby teamRating.Value.Rating descending
                                select teamRating;

            //Get the highest ranking
            var topRating = sortedTeamRatings.FirstOrDefault().Value.Rating;
            var rank = 1;

            //Set the worksheet headers
            var headers = new List<string>
            {
                "Ranking", "Team Name", "Rating", "Rating Percentage",
                "Wins", "Losses", "Percentage", "Strength of Schedule", "Weighted SoS",
                "Conference", "Division"
            };
            headers.AddRange(sortedTeamRatings.FirstOrDefault().Value.RatingComponents.Keys);
            int col = 1;
            foreach (var header in headers)
            {
                sheet.Cells[1,col++].Value = header;
            }

            //Fill in the worksheet data
            col = 1;
            int row = 2;
            foreach (var sortedTeamRating in sortedTeamRatings)
            {
                var teamName = sortedTeamRating.Key;
                var teamSeason = sortedTeamRating.Value;

                //Ranking
                sheet.Cells[row, col++].Value = rank;
                //Team Name
                sheet.Cells[row, col++].Value = teamName;
                //Rating
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Rating, 4);
                //Rating Percentage
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Rating / topRating, 4);
                //Wins
                sheet.Cells[row, col++].Value = teamSeason.Wins;
                //Losses
                sheet.Cells[row, col++].Value = teamSeason.Losses;
                //Percentage
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.Wins / Convert.ToDouble(teamSeason.Wins + teamSeason.Losses), 3);
                //Strength of Schedule
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.StrengthOfSchedule.Strength, 4);
                //Weighted SoS
                sheet.Cells[row, col++].Value = Math.Round(teamSeason.StrengthOfSchedule.WeightedStrength, 4);
                //Conference
                sheet.Cells[row, col++].Value = teamInfo[teamName].TeamInfo.Conference;
                //Division
                sheet.Cells[row, col++].Value = teamInfo[teamName].TeamInfo.Division;
                //Rating Components
                foreach (var component in teamSeason.RatingComponents.Values)
                {
                    sheet.Cells[row, col++].Value = Math.Round(component, 2);
                }
                
                //Reset the column to the start and increment the row and rank
                col = 1;
                row++;
                rank++;
            }

            //Auto fit column width
            for (int ii = 1; ii <= sheet.Dimension.End.Column; ii++)
            {
                sheet.Column(ii).AutoFit();
            }
        }

        /// <summary>
        /// Tries to open a spreadsheet file in Excel.
        /// </summary>
        /// <param name="filePath">The file to open.</param>
        private void TryOpenSpreadsheetFile(string filePath)
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