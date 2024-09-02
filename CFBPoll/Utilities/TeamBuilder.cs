using CFBPoll.Data.Modules;
using CFBPollDTOs;
using CFBPollDTOs.CFBDataAPI;
using Microsoft.Extensions.Configuration;

namespace CFBPoll.Utilities
{
    public class TeamBuilder
    {
        private readonly CFBDataAPIDataModule _cfbDataAPI;
        private readonly ExcelDataModule _excelReader;
        private readonly NameCorrector _nameCorrector;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase; 
        private readonly int _season;
        private readonly TextDataModule _textReader;
        private readonly int _week;

        public TeamBuilder(IConfiguration config, int season, int week)
        {
            _cfbDataAPI = new CFBDataAPIDataModule(config, season);
            _nameCorrector = new NameCorrector();
            _excelReader = new ExcelDataModule(config, _nameCorrector);
            _season = season;
            _textReader = new TextDataModule(config, _nameCorrector);
            _week = week;
        }

        #region public methods

        /// <summary>
        /// Creates the dictionary with all the teams from the txt file containing all the teams
        /// </summary>
        public IDictionary<string, Team> BuildTeams()
        {
            var teams = _textReader.GetTeams(_season);

            //Current Season
            var currentSeasonGames = _excelReader.GetGames(_season, _week);
            var currentSeasonOffenseStats = _excelReader.GetStatistics("offense", _season, _week);
            var currentSeasonDefenseStats = _excelReader.GetStatistics("defense", _season, _week);

            //Previous Season
            var previousSeasonGames = _excelReader.GetGames(_season-1, null);
            var previousSeasonOffenseStats = _excelReader.GetStatistics("offense", _season-1, null);
            var previousSeasonDefenseStats = _excelReader.GetStatistics("defense", _season-1, null);

            //Merge the two datasets
            var allGames = currentSeasonGames.Concat(previousSeasonGames);
            var allSeasonOffenseStats = new Dictionary<int, IDictionary<string, Statistics>>
            {
                { _season, currentSeasonOffenseStats },
                { _season - 1, previousSeasonOffenseStats }
            };
            var allSeasonDefenseStats = new Dictionary<int, IDictionary<string, Statistics>>
            {
                { _season, currentSeasonDefenseStats },
                { _season - 1, previousSeasonDefenseStats }
            };

            //Get game information from the API
            var apiGameData = _cfbDataAPI.GetBettingInformation();

            BuildTeams(teams, allGames, allSeasonOffenseStats, allSeasonDefenseStats, apiGameData);

            return teams;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Builds a dictionary of teams and their team objects using an IEnumerable of games and IDictionaries containing different seasons of statistics
        /// </summary>
        /// <param name="teamsDictionary">A dictionary of all the teams to build</param>
        /// <param name="games">All games for building teams</param>
        /// <param name="offenseStats">A dictionary of the offensive stats for each team by season</param>
        /// <param name="defenseStats">A dictionary of the defensive stats for each team by season</param>
        /// <param name="apiGameData">A list of game data from an API</param>
        /// <returns>A dictionary of teams with multiple seasons of data</returns>
        private void BuildTeams(IDictionary<string, Team> teamsDictionary, IEnumerable<Game> games, IDictionary<int, IDictionary<string, Statistics>> offenseStats, IDictionary<int, IDictionary<string, Statistics>> defenseStats, IEnumerable<CFBDataAPIGame> apiGameData)
        {
            //If there is betting data then try to set it for each game
            if (apiGameData != null && apiGameData.Any())
            {
                foreach (var game in games)
                {
                    //Find the current game in the data from the API
                    //First part of the Linq is for getting the correct Home/Away
                    //Second part of the Linq is in case of neutral site where my sistem has "home" and "away" flipped
                    var teamBettingData = apiGameData.FirstOrDefault(b => ((b.homeTeam?.Equals(_nameCorrector.FixNameForCFBDataAPI(game.HomeTeam), _scoic) ?? false) 
                                                                            && (b.awayTeam?.Equals(_nameCorrector.FixNameForCFBDataAPI(game.AwayTeam), _scoic) ?? false))
                                                                        || (b.homeTeam?.Equals(_nameCorrector.FixNameForCFBDataAPI(game.AwayTeam), _scoic) ?? false)
                                                                            && (b.awayTeam?.Equals(_nameCorrector.FixNameForCFBDataAPI(game.HomeTeam), _scoic) ?? false));

                    var bettingInfo = new List<Lines>();

                    //Add each line to the betting info
                    if (teamBettingData != null)
                        foreach (var data in teamBettingData.lines)
                            bettingInfo.Add(new Lines(data));

                    //Set the betting info for the game
                    game.Lines = bettingInfo;
                }
            }

            //Build set the information for the teams
            foreach (var teamRecord in teamsDictionary)
            {
                var teamName = teamRecord.Key;
                var team = teamRecord.Value;

                if (!offenseStats[_season].ContainsKey(teamName) && !defenseStats[_season].ContainsKey(teamName))
                    continue;

                //Add the current season records
                team.Seasons.Add(_season, new Season()
                {
                    RatingDetails = new RatingDetails()
                    {
                        OffenseStatistics = offenseStats[_season][teamName],
                        DefenseStatistics = defenseStats[_season][teamName],
                        TeamName = teamName,
                    },
                    Games = games.Where(g => (g.HomeTeam.Equals(teamName, _scoic) || g.AwayTeam.Equals(teamName, _scoic)) && g.Season.Equals(_season)),
                    Year = _season
                });

                //Add the previous season if it exists
                if (offenseStats[_season - 1].ContainsKey(teamName) && defenseStats[_season - 1].ContainsKey(teamName))
                {
                    team.Seasons.Add(_season - 1, new Season()
                    {
                        RatingDetails = new RatingDetails()
                        {
                            OffenseStatistics = offenseStats[_season - 1][teamName],
                            DefenseStatistics = defenseStats[_season - 1][teamName],
                            TeamName = teamName,
                        },
                        Games = games.Where(g => (g.HomeTeam.Equals(teamName, _scoic) || g.AwayTeam.Equals(teamName, _scoic)) && g.Season.Equals(_season - 1)),
                        Year = _season - 1
                    });
                }                
            }
        }

        #endregion
    }
}
