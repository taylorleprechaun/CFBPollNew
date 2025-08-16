using CFBPoll.DTOs;

namespace CFBPoll.System.Data.Interfaces
{
    public interface IStatisticsData
    {
        /// <summary>
        /// Insert team statistics for a given type, season, and week.
        /// </summary>
        /// <param name="statisticsType">The type of statistics.</param>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        /// <param name="teamStatistics">The team statistics.</param>
        /// <returns>The result.</returns>
        Task<string> Statistics_Insert(string statisticsType, int season, int week, IDictionary<string, Statistics> teamStatistics);
    }
}
