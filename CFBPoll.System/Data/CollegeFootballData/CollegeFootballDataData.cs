using CFBPoll.System.Data.CollegeFootballData.Internal;
using CFBPoll.Utilities;
using CollegeFootballData;
using CollegeFootballData.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace CFBPoll.System.Data.CollegeFootballData
{
    public class CollegeFootballDataData
    {
        private readonly string _apiKey;
        private readonly ApiClient _apiClient;

        public CollegeFootballDataData()
        {
            _apiKey = ConfigurationHelper.GetConfiguration("CFBDataApiKey");
            _apiClient = GetCollegeFootballDataAPIClient();
        }

        #region public methods

        /// <summary>
        /// Get all games for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>A dictionary with the school's name as the key and a collection of games as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<Game>>> GetGames(int season)
        {
            var games = await _apiClient.Games.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
                requestConfiguration.QueryParameters.ClassificationAsDivisionClassification = DivisionClassification.Fbs;
            });

            if (games == null || !games.Any())
                return new Dictionary<string, IEnumerable<Game>>();

            var teamGames = games.Where(g => g != null && !string.IsNullOrEmpty(g.HomeTeam) && !string.IsNullOrEmpty(g.AwayTeam))?
                            .SelectMany(game => new[]
                            {
                                    new { Team = game.HomeTeam!, Game = game },
                                    new { Team = game.AwayTeam!, Game = game }
                            })
                            .GroupBy(x => x.Team)
                            .ToDictionary(g => g.Key, g => g.Select(x => x.Game));
            return teamGames ?? new Dictionary<string, IEnumerable<Game>>();
        }

        /// <summary>
        /// Get all game stats for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>A dictionary with the school's name as the key and a collection of game stats as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<AdvancedGameStat>>> GetGameStats(int season)
        {
            var gameStats = await _apiClient.Stats.Game.Advanced.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
            });

            if (gameStats == null || !gameStats.Any())
                return new Dictionary<string, IEnumerable<AdvancedGameStat>>();

            var teamGameStats = gameStats.Where(gs => !string.IsNullOrEmpty(gs?.Team))?
                                        .GroupBy(gs => gs.Team!)?
                                        .Where(g => g != null && !string.IsNullOrEmpty(g?.Key) && g.Any())?
                                        .ToDictionary(g => g.Key, g => g.AsEnumerable());

            return teamGameStats ?? new Dictionary<string, IEnumerable<AdvancedGameStat>>();
        }


        /// <summary>
        /// Get all FBS teams for a given season.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>A dictionary with the school's name as the key and the team information as the value.</returns>
        public async Task<IDictionary<string, Team>> GetTeams(int season)
        {
            var teams = await _apiClient.Teams.Fbs.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
            });

            if (teams == null || !teams.Any())
                return new Dictionary<string, Team>();

            return teams.Where(t => !string.IsNullOrEmpty(t?.School))?
                        .ToDictionary(t => t.School!, t => t) ?? new Dictionary<string, Team>();
        }

        /// <summary>
        /// Get all team stats for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>A dictionary with the school's name as the key and their team stats as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<TeamStat>>> GetTeamStats(int season)
        {
            var teamStats = await _apiClient.Stats.Season.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
            });

            if (teamStats == null || !teamStats.Any())
                return new Dictionary<string, IEnumerable<TeamStat>>();

            //Group the collection by the team name and return as a dictionary
            var groupedTeamStats = teamStats!.Where(ts => !string.IsNullOrEmpty(ts?.Team))?
                                            .GroupBy(ts => ts.Team!)?
                                            .Where(g => g != null && !string.IsNullOrEmpty(g?.Key) && g.Any())?
                                            .ToDictionary(g => g.Key, g => g.AsEnumerable());
            return groupedTeamStats ?? new Dictionary<string, IEnumerable<TeamStat>>();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Get an authenticated API client for the College Football Data API.
        /// </summary>
        /// <returns>An ApiClient ready to use to call the College Football Data API.</returns>
        private ApiClient GetCollegeFootballDataAPIClient()
        {
            var authProvider = new BaseBearerTokenAuthenticationProvider(new StaticAccessTokenProvider(_apiKey));
            var httpClient = new HttpClient();
            var requestAdapter = new HttpClientRequestAdapter(authProvider, httpClient: httpClient);
            var client = new ApiClient(requestAdapter);

            return client;
        }

        #endregion
    }
}
