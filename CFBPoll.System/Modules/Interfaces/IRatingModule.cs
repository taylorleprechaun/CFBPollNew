using CFBPoll.DTOs.Rating;
using CFBPoll.DTOs.Scenarios;

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

        /// <summary>
        /// Rates the rating scenario request.
        /// </summary>
        /// <param name="scenariosRequest">The scenario information used to rate the teams.</param>
        /// <returns>A collection of scenario results.</returns>
        IEnumerable<ScenarioResult> RateScenarios(ScenarioRequest scenariosRequest);
    }
}