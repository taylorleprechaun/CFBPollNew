namespace CFBPoll.DTOs
{
    public class RatingDetails
    {
        public Statistics DefenseStatistics { get; set; }
        public Statistics OffenseStatistics { get; set; }
        public double Rating { get; set; }
        public double StrengthOfSchedule { get; set; }
        public string TeamName {  get; set; }
        public double WeightedStrengthOfSchedule { get; set; }

        public RatingDetails() { }

        public RatingDetails(Statistics defenseStats, Statistics offenseStats, double rating, double strengthOfSchedule, string teamName, double weightedStrengthOfSchedule)
        {
            DefenseStatistics = defenseStats;
            OffenseStatistics = offenseStats;
            Rating = rating;
            StrengthOfSchedule = strengthOfSchedule;
            TeamName = teamName;
            WeightedStrengthOfSchedule = weightedStrengthOfSchedule;
        }
    }
}
