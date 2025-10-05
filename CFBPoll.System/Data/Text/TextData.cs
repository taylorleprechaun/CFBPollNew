using CFBPoll.DTOs;
using CFBPoll.DTOs.Rating;
using CFBPoll.Utilities;
using System.Diagnostics;
using System.Text;

namespace CFBPoll.System.Data.Text
{
    public class TextData
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private readonly string _txtPollFilePath = string.Empty;

        public TextData()
        {
            _txtPollFilePath = ConfigurationHelper.GetConfiguration("PollOutputPath_txt");
        }

        #region public methods

        /// <summary>
        /// Prints the poll to a txt file with table formatting.
        /// </summary>
        /// <param name="teamInfo">Team information.</param>
        /// <param name="ratingDetails">The rating details to print.</param>
        public void PrintPollTable(IDictionary<string, TeamDetail> teamInfo, IDictionary<string, RatingDetail> ratingDetails)
        {
            //Delete output file if it exists
            if (File.Exists(_txtPollFilePath))
                File.Delete(_txtPollFilePath);

            //Convert our dictionary of teams into one for the current season and sort by rating descending
            var sortedSeasons = from teamRating in ratingDetails 
                                orderby teamRating.Value.Rating descending 
                                select teamRating;

            //Get the highest ranking
            var topRating = sortedSeasons.FirstOrDefault().Value.Rating;
            var rank = 1;

            //Sort strength of schedule for printing
            var sosRank = 1;
            var strengthOfScheduleRankings = (from teamRating in ratingDetails 
                                             orderby teamRating.Value.StrengthOfSchedule.WeightedStrength descending 
                                             select teamRating).ToDictionary(s => s.Key, s => sosRank++);

            //Table header
            var txt = new StringBuilder();
            txt.AppendLine("Rank | Team | Rating | Record | SoS | SoS Rank\n---|---|---|---|---|---");

            //Loop through teams
            for (int ii = 0; ii < sortedSeasons.Count(); ii++)
            {
                var sortedSeason = sortedSeasons.ElementAt(ii);
                var teamName = sortedSeason.Key;
                var teamSeason = sortedSeason.Value;
                var wins = teamInfo[teamName].Games.Count();


                //Add info
                string nextLine = ""
                    + $"{rank} | "
                    + $"{sortedSeason.Key} | "
                    + $"{string.Format("{0:0.0000}", Math.Truncate(teamSeason.Rating / topRating * 10000) / 10000)} | "
                    + $"{teamSeason.Wins + "-" + teamSeason.Losses} | "
                    + $"{string.Format("{0:0.0000}", teamSeason.StrengthOfSchedule.WeightedStrength)} | "
                    + $"{strengthOfScheduleRankings[teamName]}"
                    + $"\n";

                //Append to csv output
                txt.Append(nextLine);

                //Increment rank
                rank++;
            }

            //Write to output
            File.WriteAllText(_txtPollFilePath, txt.ToString());

            //Open the file
            TryOpenTextFile(_txtPollFilePath);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Tries to open a text file in Notepad++ and falls back to Notepad.
        /// </summary>
        /// <param name="filePath">The file to open.</param>
        private void TryOpenTextFile(string filePath)
        {
            try
            {
                Process.Start(@"C:\Program Files (x86)\Notepad++\notepad++.exe", filePath);
            }
            catch (Exception)
            {
                Process.Start("notepad.exe", _txtPollFilePath);
            }
        }

        #endregion
    }
}