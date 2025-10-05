using CFBPoll.DTOs;
using CFBPoll.System.Data.CollegeFootballData;

namespace CFBPoll.System.Modules.Default
{
    public class DefaultCFBModule
    {
        private readonly CollegeFootballDataData _cfbData;

        public DefaultCFBModule()
        {
            _cfbData = new CollegeFootballDataData();
        }

        public async Task<IDictionary<string, TeamDetail>> GetTeamDetails(int season, int week)
        {
            return await _cfbData.GetTeamDetails(season, week);
        }
    }
}
