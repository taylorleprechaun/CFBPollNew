namespace CFBPoll.DTOs.Rating
{
    public class RatingRequest
    {
        public int Season { get; set; }
        public IDictionary<string, TeamDetail> TeamDetails { get; set; }
        public int Week { get; set; }
        
    }
}
