namespace CFBPoll.System.Data.Interfaces
{
    public interface IScoresData
    {
        /// <summary>
        /// Insert scores for a given season and week.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        /// <returns>The result.</returns>
        string Scores_Insert(int season, int week);
    }
}
