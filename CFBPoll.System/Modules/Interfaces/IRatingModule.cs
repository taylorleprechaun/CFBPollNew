using CFBPoll.DTOs;

namespace CFBPoll.System.Modules.Interfaces
{
    public interface IRatingModule
    {
        /// <summary>
        /// Gets a collection of the rating details from a dictionary of teams.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <returns>A collection of rating details.</returns>
        IEnumerable<RatingDetails> GetRatingDetails(IDictionary<string, Team> teams);

        /// <summary>
        /// Rates the teams in the given dictionary.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <returns>A dictionary of teams with ratings.</returns>
        IDictionary<string, Team> RateTeams(IDictionary<string, Team> teams);
    }
}
