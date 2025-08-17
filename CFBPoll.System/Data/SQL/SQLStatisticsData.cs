using CFBPoll.DTOs;
using CFBPoll.System.Data.Interfaces;
using Dapper;
using System.Data;

namespace CFBPoll.System.Data.SQL
{
    public class SQLStatisticsData : BaseData, IStatisticsData
    {
        public SQLStatisticsData() : base() { }

        #region public methods

        public async Task<string> Statistics_Insert(string statisticsType, int season, int week, IDictionary<string, Statistics> teamStatistics)
        {
            const string storedProcedure = "Poll.TeamStatistics_Insert";
            var parameters = new DynamicParameters();
            parameters.Add("@TeamStatData", ToTeamStatDataTable(statisticsType, season, week, teamStatistics).AsTableValuedParameter("Poll.udtTeamStatistics"));
            
            var result = await _dapperExecutor.ExecuteStoredProcedureAsync<string>(
                storedProcedure,
                parameters);

            return result?.FirstOrDefault() ?? string.Empty;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Converts the team statistics into a DataTable for insertion into the database.
        /// </summary>
        /// <param name="statisticsType">The type of statistics.</param>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        /// <param name="teamStatistics">The team statistics.</param>
        /// <returns>A DataTable containing the team statistics to insert into the database.</returns>
        private DataTable ToTeamStatDataTable(string statisticsType, int season, int week, IDictionary<string, Statistics> teamstatistics)
        {
            var table = new DataTable();
            table.Columns.Add("TeamName", typeof(string));
            table.Columns.Add("StatisticsType", typeof(string));
            table.Columns.Add("Season", typeof(int));
            table.Columns.Add("Week", typeof(int));
            table.Columns.Add("Games", typeof(int));
            table.Columns.Add("Points", typeof(decimal));
            table.Columns.Add("PassCompletions", typeof(decimal));
            table.Columns.Add("PassAttempts", typeof(decimal));
            table.Columns.Add("PassPercent", typeof(decimal));
	        table.Columns.Add("PassYards", typeof(decimal));
	        table.Columns.Add("PassTDs", typeof(decimal));
	        table.Columns.Add("RushAttempts", typeof(decimal));
	        table.Columns.Add("RushYards", typeof(decimal));
	        table.Columns.Add("RushAverage", typeof(decimal));
	        table.Columns.Add("RushTDs", typeof(decimal));
	        table.Columns.Add("TotalPlays", typeof(decimal));
	        table.Columns.Add("TotalYards", typeof(decimal));
	        table.Columns.Add("FirstDownsPass", typeof(decimal));
	        table.Columns.Add("FirstDownsRush", typeof(decimal));
	        table.Columns.Add("FirstDownsPenalty", typeof(decimal));
	        table.Columns.Add("FirstDownsTotal", typeof(decimal));
	        table.Columns.Add("PenaltiesNumber", typeof(decimal));
	        table.Columns.Add("PenaltiesYards", typeof(decimal));
	        table.Columns.Add("TurnoversFumble", typeof(decimal));
	        table.Columns.Add("TurnoversInterception", typeof(decimal));
            table.Columns.Add("TurnoversTotal", typeof(decimal));

            foreach (var kvp in teamstatistics)
            {
                var teamName = kvp.Key;
                var statistics = kvp.Value;
                if (string.IsNullOrEmpty(teamName) || statistics == null)
                    continue;

                table.Rows.Add(teamName, statisticsType, season, week, statistics.Games
                    ,statistics.Points, statistics.PassCompletions, statistics.PassAttempts
                    ,statistics.PassPercent, statistics.PassYards, statistics.PassTD
                    ,statistics.RushAttempts, statistics.RushYards, statistics.RushAvg
                    ,statistics.RushTD, statistics.Plays, statistics.TotalYards
                    ,statistics.PassFirsts, statistics.RushFirsts, statistics.PenaltyFirsts
                    ,statistics.TotalFirsts, statistics.Penalties, statistics.PenaltyYards
                    ,statistics.Fumbles, statistics.Interceptions, statistics.TotalTO);
            }

            return table;
        }

        #endregion
    }
}
