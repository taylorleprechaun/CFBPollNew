using CFBPoll.DTOs;
using CFBPoll.DTOs.Rating;
using CFBPoll.DTOs.Scenarios;
using CFBPoll.System.Modules.Factories;
using CollegeFootballData.Models;

namespace CFBPoll.System.Modules.Default
{
    public class DefaultScenariosModule
    {
        public DefaultScenariosModule()
        {
        }

        /// <summary>
        /// Get the games that can be used for scenario analysis.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="week">The week.</param>
        /// <param name="teamDetails">The collection of team data to get the games from.</param>
        /// <returns>A collection of games that can be used for scenario analysis.</returns>
        public IEnumerable<Game> GetGames(int season, int week, IDictionary<string, TeamDetail> teamDetails)
        {
            //Return all of the games for the given season and week that have not been played yet
            return teamDetails?.Values?.Where(t => t?.Games != null && t.Games.Any())?.SelectMany(t => t.Games)?
                                        .Where(game => game != null && game.Season == season && game.Week == week && game.Completed == false)?
                                        .DistinctBy(g => g.Id)
                ?? new List<Game>();
        }

        /// <summary>
        /// Generate team rating scenarios based on provided games.
        /// </summary>
        /// <param name="scenariosRequest">The scenarios to rate</param>
        /// <returns>A collection of rating details based on the provided scenarios.</returns>
        public IEnumerable<ScenarioResult> RateScenarios(ScenarioRequest scenariosRequest)
        {
            if (scenariosRequest == null || scenariosRequest.TeamDetails?.Any() != true || scenariosRequest.GameIDs?.Any() != true)
                return new List<ScenarioResult>();

            var rater = RatingFactory.GetRatingModule(scenariosRequest.Season);
            return rater.RateScenarios(scenariosRequest);
        }
    }
}
