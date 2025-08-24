using CFBPoll.DTOs;

namespace CFBPoll.System.Data.Interfaces
{
    public interface ITeamsData
    {
        /// <summary>
        /// Insert teams for a given season.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="teams">The teams.</param>
        /// <returns>The result.</returns>
        Task<string> Teams_Insert(int season, IEnumerable<Team> teams);
    }
}
