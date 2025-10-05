namespace CFBPoll.DTOs.Rating;

public class RatingDetail
{
    public int Losses { get; set; }
    public double Rating { get; set; }
    public IDictionary<string, double> RatingComponents { get; set; }
    public StrengthOfSchedule StrengthOfSchedule { get; set; }
    public string TeamName { get; set; }
    public int Wins { get; set; }
}
