using CFBPoll.DTOs;
using CFBPoll.System.Data.Interfaces;
using Dapper;
using System.Data;

namespace CFBPoll.System.Data.SQL
{
    public class SQLScoresData : BaseData, IScoresData
    {
        public SQLScoresData() : base() { }

        #region public methods

        public async Task<string> Scores_Insert(int season, IEnumerable<Game> games)
        {
            const string storedProcedure = "Poll.TeamScores_Insert";
            var parameters = new DynamicParameters();
            parameters.Add("@TeamScoresData", ToTeamScoresDataTable(season, games).AsTableValuedParameter("Poll.udtTeamScores"));

            var result = await _dapperExecutor.ExecuteStoredProcedureAsync<string>(
                storedProcedure,
                parameters);

            return result?.FirstOrDefault() ?? string.Empty;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Converts the team games into a DataTable for insertion into the database.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="games">The team games.</param>
        /// <returns>A DataTable containing the team games to insert into the database.</returns>
        private DataTable ToTeamScoresDataTable(int season, IEnumerable<Game> games)
        {
            var table = new DataTable();
            table.Columns.Add("Season", typeof(int));
            table.Columns.Add("Week", typeof(int));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("HomeTeam", typeof(string));
            table.Columns.Add("HomeScore", typeof(double));
            table.Columns.Add("AwayTeam", typeof(string));
            table.Columns.Add("AwayScore", typeof(double));
            table.Columns.Add("IsNeutralSite", typeof(bool));


            foreach (var game in games)
            {
                //Skip null games, missing teams, missing dates, or games that haven't happened yet
                if (game == null || string.IsNullOrEmpty(game.HomeTeam) || string.IsNullOrEmpty(game.AwayTeam)
                    || game.Date == null || game.Date == DateTime.MinValue || game.FutureGame)
                    continue;

                table.Rows.Add(season, game.Week, game.Date.Value
                    ,game.HomeTeam, game.HomePoints
                    ,game.AwayTeam, game.AwayPoints
                    ,game.NeutralSite);
            }

            return table;
        }

        #endregion
    }
}
