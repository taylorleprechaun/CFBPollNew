using CFBPoll.DTOs.Rating;

namespace CFBPoll.DTOs.Scenarios
{
    public class ScenarioResult
    {
        public IEnumerable<int?> GameIDs { get; set; }
        public IDictionary<string, RatingDetail> RatingDetails { get; set; }
        public IEnumerable<string> Scenario { get; set; }
    }
}
