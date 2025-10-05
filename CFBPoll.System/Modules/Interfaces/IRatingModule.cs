using CFBPoll.DTOs.Rating;

namespace CFBPoll.System.Modules.Interfaces
{
    public interface IRatingModule
    {
        /// <summary>
        /// Rates the rating request.
        /// </summary>
        /// <param name="ratingRequest">The information used to rate the teams.</param>
        /// <returns>A dictionary of teams with rating details.</returns>
        IDictionary<string, RatingDetail> RateTeams(RatingRequest ratingRequest);
    }
}