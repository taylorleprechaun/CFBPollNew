using CFBPoll.System.Data.CollegeFootballData;
using CollegeFootballData.Models;

namespace CFBPoll.System.Modules.Default
{
    public class DefaultCFBModule
    {
        private readonly CollegeFootballDataData _cfbData;

        public DefaultCFBModule()
        {
            _cfbData = new CollegeFootballDataData();
        }

        public async Task<IDictionary<string, IEnumerable<Game>>> GetGames(int season)
        {
            return await _cfbData.GetGames(season);
        }

        public async Task<IDictionary<string, IEnumerable<AdvancedGameStat>>> GetGameStats(int season)
        {
            return await _cfbData.GetGameStats(season);
        }

        public async Task<IDictionary<string, Team>> GetTeams(int season)
        {
            return await _cfbData.GetTeams(season);
        }

        public async Task<IDictionary<string, IEnumerable<TeamStat>>> GetTeamStats(int season)
        {
            return await _cfbData.GetTeamStats(season);
        }
    }
}
