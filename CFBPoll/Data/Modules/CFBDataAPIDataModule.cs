using CFBPoll.Utilities;
using CFBPollDTOs.CFBDataAPI;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CFBPoll.Data.Modules
{
    public class CFBDataAPIDataModule
    {
        private readonly string _apiKey;
        private readonly string _endpoint;
        private readonly int _season;

        public CFBDataAPIDataModule(IConfiguration config, int season)
        {
            _apiKey = config.GetSection("AppSettings:CFBDataAPIKey").Value ?? string.Empty;
            _endpoint = $"https://api.collegefootballdata.com";
            _season = season;
        }

        #region public methods

        #region betting

        /// <summary>
        /// Gets betting information for the season
        /// </summary>
        /// <returns>An enumerable containing game results including betting lines</returns>
        public IEnumerable<CFBDataAPIGame> GetBettingInformation()
        {
            var apiGameData = new List<CFBDataAPIGame>();

            if (!IsValidRequest()) return apiGameData;

            //We get all the game data for the season at once rather than call the API many many times for specific games
            var result = RESTProvider.GetStringReturn($"{_endpoint}/lines?year={_season}", GetHeaders());
            if (!string.IsNullOrEmpty(result))
                apiGameData = JsonConvert.DeserializeObject<List<CFBDataAPIGame>>(result);

            return apiGameData;
        }

        #endregion

        #endregion

        #region private methods

        /// <summary>
        /// Gets the headers for the API request
        /// </summary>
        /// <returns>A dictionary containing the request headers</returns>
        private IDictionary<string, string> GetHeaders() 
        {
            return new Dictionary<string, string>() {
                { "Accept", "application/json" },
                { "Authorization", $"Bearer {_apiKey}" },
                { "Content-Type", "application/json" },
            };
        }

        /// <summary>
        /// Checks if the request is valid
        /// </summary>
        /// <returns>True if it is. False if it isn't</returns>
        private bool IsValidRequest()
        {
            return !string.IsNullOrEmpty(_apiKey)
                && !string.IsNullOrEmpty(_endpoint)
                && _season != 0;
        }

        #endregion
    }
}
