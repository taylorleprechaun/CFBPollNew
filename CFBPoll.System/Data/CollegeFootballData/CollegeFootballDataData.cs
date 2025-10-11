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
        /// Get the team details in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="seasonType">Regular or Postseason.</param>
        /// <param name="week">The week.</param>
        /// <returns>A dictionary with the school's name as the key and all their relevant information as the value.</returns>
        public async Task<IDictionary<string, DTOs.TeamDetail>> GetTeamDetails(int season, string seasonType, int week)
        {
            var teamDetails = new Dictionary<string, DTOs.TeamDetail>();
            if (string.IsNullOrEmpty(seasonType))
                return teamDetails;

            var seasonTypeEnum = seasonType.Equals("Regular", StringComparison.OrdinalIgnoreCase) ? SeasonType.Regular : SeasonType.Both;

            //Do all the API calls asynchronously
            var teams = GetTeams(season);
            var games = GetGames(season, seasonTypeEnum);
            var teamStats = GetTeamStats(season, seasonTypeEnum, week);
            var gameStats = GetGameStats(season, seasonTypeEnum);
            await Task.WhenAll(teams, games, teamStats, gameStats);

            //If the teams result is null then stop
            if (teams.Result == null || !teams.Result.Any())
                return teamDetails;

            //Build the team details dictionary
            foreach (var team in teams.Result)
            {
                if (string.IsNullOrEmpty(team.Key) || team.Value == null)
                    continue;

                var detail = new DTOs.TeamDetail
                {
                    TeamInfo = team.Value,
                    Games = games.Result?.TryGetValue(team.Key, out IEnumerable<Game>? gameValue) == true && gameValue != null
                                ? gameValue : [],
                    TeamStats = teamStats.Result?.TryGetValue(team.Key, out IEnumerable<TeamStat>? teamStatValue) == true && teamStatValue != null 
                                ? teamStatValue : [],
                    GameStats = gameStats.Result?.TryGetValue(team.Key, out IEnumerable<AdvancedGameStat>? advancedGameStatValue)== true && advancedGameStatValue != null 
                                ? advancedGameStatValue : []
                };
                teamDetails[team.Key] = detail;
            }

            return teamDetails;
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

        /// <summary>
        /// Get all games for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="seasonType">The season type.</param>
        /// <returns>A dictionary with the school's name as the key and a collection of games as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<Game>>> GetGames(int season, SeasonType seasonType)
        {
            var games = await _apiClient.Games.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
                requestConfiguration.QueryParameters.ClassificationAsDivisionClassification = DivisionClassification.Fbs;
                requestConfiguration.QueryParameters.SeasonTypeAsSeasonType = seasonType;
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
            return teamGames ?? [];
        }

        /// <summary>
        /// Get all game stats for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="seasonType">The season type.</param>
        /// <returns>A dictionary with the school's name as the key and a collection of game stats as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<AdvancedGameStat>>> GetGameStats(int season, SeasonType seasonType)
        {
            var gameStats = await _apiClient.Stats.Game.Advanced.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
                requestConfiguration.QueryParameters.SeasonTypeAsSeasonType = seasonType;
            });

            if (gameStats == null || !gameStats.Any())
                return new Dictionary<string, IEnumerable<AdvancedGameStat>>();

            var teamGameStats = gameStats.Where(gs => !string.IsNullOrEmpty(gs?.Team))?
                                        .GroupBy(gs => gs.Team!)?
                                        .Where(g => g != null && !string.IsNullOrEmpty(g?.Key) && g.Any())?
                                        .ToDictionary(g => g.Key, g => g.AsEnumerable());

            return teamGameStats ?? [];
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
                        .ToDictionary(t => t.School!, t => t) ?? [];
        }

        /// <summary>
        /// Get all team stats for a given season in a dictionary where the key is the school's name.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <param name="seasonType">The season type.</param>
        /// <param name="week">The week to get the team stats up until.</param>
        /// <returns>A dictionary with the school's name as the key and their team stats as the value.</returns>
        public async Task<IDictionary<string, IEnumerable<TeamStat>>> GetTeamStats(int season, SeasonType seasonType, int week)
        {
            var teamStats = await _apiClient.Stats.Season.GetAsync(requestConfiguration =>
            {
                requestConfiguration.QueryParameters.Year = season;
                requestConfiguration.QueryParameters.EndWeek = seasonType.Equals(SeasonType.Both) ? null : week;
            });

            if (teamStats == null || !teamStats.Any())
                return new Dictionary<string, IEnumerable<TeamStat>>();

            var groupedTeamStats = teamStats!.Where(ts => !string.IsNullOrEmpty(ts?.Team))?
                                            .GroupBy(ts => ts.Team!)?
                                            .Where(g => g != null && !string.IsNullOrEmpty(g?.Key) && g.Any())?
                                            .ToDictionary(g => g.Key, g => g.AsEnumerable());
            return groupedTeamStats ?? [];
        }

        #endregion
    }
}
