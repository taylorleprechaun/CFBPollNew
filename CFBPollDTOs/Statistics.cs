namespace CFBPollDTOs
{
    public class Statistics
    {
        public double Fumbles { get; set; }
        public int Games { get; set; }
        public double Interceptions { get; set; }
        public double Points { get; set; }
        public double PassAttempts { get; set; }
        public double PassCompletions { get; set; }
        public double PassFirsts { get; set; }
        public double PassPercent { get; set; }
        public double PassTD { get; set; }
        public double PassYards { get; set; }
        public double Plays { get; set; }
        public double Penalties { get; set; }
        public double PenaltyFirsts { get; set; }
        public double PenaltyYards { get; set; }
        public double RushAttempts { get; set; }
        public double RushAvg { get; set; }
        public double RushFirsts { get; set; }
        public double RushTD { get; set; }
        public double RushYards { get; set; }
        public double TotalFirsts { get; set; }
        public double TotalTO { get; set; }
        public double TotalYards { get; set; }

        public Statistics() { }

        public Statistics(double fumbles, int games, double interceptions, double points, double passAttempts, double passCompletions, double passFirsts, double passPercent, double passTD, double passYards, double plays, double penalties, double penaltyFirsts, double penaltyYards, double rushAttempts, double rushAvg, double rushFirsts, double rushTD, double rushYards, double totalFirsts, double totalTO, double totalYards)
        {
            Fumbles = fumbles;
            Games = games;
            Interceptions = interceptions;
            Points = points;
            PassAttempts = passAttempts;
            PassCompletions = passCompletions;
            PassFirsts = passFirsts;
            PassPercent = passPercent;
            PassTD = passTD;
            PassYards = passYards;
            Plays = plays;
            Penalties = penalties;
            PenaltyFirsts = penaltyFirsts;
            PenaltyYards = penaltyYards;
            RushAttempts = rushAttempts;
            RushAvg = rushAvg;
            RushFirsts = rushFirsts;
            RushTD = rushTD;
            RushYards = rushYards;
            TotalFirsts = totalFirsts;
            TotalTO = totalTO;
            TotalYards = totalYards;
        }
    }
}
