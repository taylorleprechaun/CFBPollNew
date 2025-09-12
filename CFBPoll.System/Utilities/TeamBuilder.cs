using CFBPoll.DTOs;
using CFBPoll.System.Data.Modules;
using CFBPoll.System.Data.Text;
using Microsoft.Extensions.Configuration;

namespace CFBPoll.System.Utilities
{
    public class TeamBuilder
    {
        private readonly ExcelData _excelReader;
        private readonly NameCorrector _nameCorrector;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase; 
        private readonly int _season;
        private readonly TextData _textReader;
        private readonly int _week;

        public TeamBuilder(IConfiguration config, int season, int week)
        {
            _nameCorrector = new NameCorrector();
            _excelReader = new ExcelData(config, _nameCorrector);
            _season = season;
            _textReader = new TextData(config, _nameCorrector);
            _week = week;
        }

        #region public methods

        /// <summary>
        /// Creates the dictionary with all the teams from the txt file containing all the teams
        /// </summary>
        public IDictionary<string, Team> BuildTeams()
        {
            var teams = _textReader.GetTeams(_season);

            //Remove FCS teams
            if (teams != null && teams.ContainsKey("FCS Team"))
                teams.Remove("FCS Team");

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

            BuildTeams(teams, allGames, allSeasonOffenseStats, allSeasonDefenseStats);

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
        /// <returns>A dictionary of teams with multiple seasons of data</returns>
        private void BuildTeams(IDictionary<string, Team> teamsDictionary, IEnumerable<Game> games, IDictionary<int, IDictionary<string, Statistics>> offenseStats, IDictionary<int, IDictionary<string, Statistics>> defenseStats)
        {           
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
