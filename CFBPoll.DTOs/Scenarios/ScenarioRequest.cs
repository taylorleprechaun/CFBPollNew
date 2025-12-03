using CFBPoll.DTOs.Rating;

namespace CFBPoll.DTOs.Scenarios
{
    public class ScenarioRequest : RatingRequest
    {
        public IEnumerable<int?> GameIDs { get; set; }
    }
}
