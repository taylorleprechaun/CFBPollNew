using CFBPollDTOs;

namespace CFBPoll.Calculations.Interfaces
{
    public interface IRating
    {
        /// <summary>
        /// Rates the teams in the given dictionary
        /// </summary>
        /// <param name="teams">The teams</param>
        /// <returns>A dictionary of teams with ratings</returns>
        IDictionary<string, Team> RateTeams(IDictionary<string, Team> teams);
    }
}
