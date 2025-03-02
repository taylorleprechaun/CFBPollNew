namespace CFBPoll.Domain.Entities
{
    public class RankingDetail
    {
        public int Rank { get; init; }
        public decimal Rating { get; init; }
        public string Record { get; init; }
        public decimal? StrengthOfSchedule { get; init; }
        public int? StrengthOfScheduleRank { get; init; }
        public string TeamName { get; init; }
    }
}
