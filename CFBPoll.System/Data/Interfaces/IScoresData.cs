using CFBPoll.DTOs;

namespace CFBPoll.System.Data.Interfaces
{
    public interface IScoresData
    {
        /// <summary>
        /// Insert scores for a given season and week.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="games">The games to insert.</param>
        /// <returns>The result.</returns>
        Task<string> Scores_Insert(int season, IEnumerable<Game> games);
    }
}
