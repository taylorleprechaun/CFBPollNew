using CollegeFootballData.Models;

namespace CFBPoll.DTOs
{
    public class TeamDetail
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<AdvancedGameStat> GameStats { get; set; }
        public Team TeamInfo { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; }
    }
}
