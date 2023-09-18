namespace CFBPollDTOs.CFBDataAPI
{
    public class CFBDataAPIGame
    {
        public string? awayConference { get; set; }
        public int? awayScore { get; set; }
        public string? awayTeam { get; set; }
        public string? homeConference { get; set; }
        public int? homeScore { get; set; }
        public string? homeTeam { get; set; }
        public int? id { get; set; }
        public IEnumerable<CFBDataAPIBetting> lines { get; set; }
        public int? season { get; set; }
        public string? seasonType { get; set; }
        public DateTime? startDate { get; set; }
        public int? week { get; set; }
    }
}
