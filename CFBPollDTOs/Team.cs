namespace CFBPollDTOs
{
    public class Team
    {
        public string Conference { get; set; }
        public string Division { get; set; }
        public string Name { get; set; }
        public IDictionary<int, Season> Seasons { get; set; }
        
        public Team(string name, string conference, string division, IDictionary<int, Season> seasons)
        {
            Name = name;
            Conference = conference;
            Division = division;
            Seasons = seasons;
        }
    }
}
