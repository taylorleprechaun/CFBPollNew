using CFBPoll.DTOs;
using CFBPoll.System.Data.Interfaces;
using Dapper;
using System.Data;

namespace CFBPoll.System.Data.SQL
{
    public class SQLTeamsData : BaseData, ITeamsData
    {
        public SQLTeamsData() : base() { }

        #region public methods

        public async Task<string> Teams_Insert(int season, IEnumerable<Team> teams)
        {
            const string storedProcedure = "Poll.TeamVersion_Insert";
            var parameters = new DynamicParameters();
            parameters.Add("@TeamVersionData", ToTeamVersionDataTable(season, teams).AsTableValuedParameter("Poll.udtTeamVersion"));

            var result = await _dapperExecutor.ExecuteStoredProcedureAsync<string>(
                storedProcedure,
                parameters);

            return result?.FirstOrDefault() ?? string.Empty;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Converts the team versions into a DataTable for insertion into the database.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="teams">The teams.</param>
        /// <returns>A DataTable containing the team information to insert into the database.</returns>
        private DataTable ToTeamVersionDataTable(int season, IEnumerable<Team> teams)
        {
            var table = new DataTable();
            table.Columns.Add("TeamName", typeof(string));
            table.Columns.Add("Conference", typeof(string));
            table.Columns.Add("Division", typeof(string));
            table.Columns.Add("Season", typeof(int));

            foreach (var team in teams)
            {
                table.Rows.Add(team.Name, team.Conference, team.Division, season);
            }

            return table;
        }

        #endregion
    }
}
