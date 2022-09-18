using ClosedXML.Excel;

namespace CFBPollNew
{
    class Stats
    {
        public int Games { get; set; }
        public double Points { get; set; }
        public double PassCompletions { get; set; }
        public double PassAttempts { get; set; }
        public double PassPercent { get; set; }
        public double PassYards { get; set; }
        public double PassTD { get; set; }
        public double RushAttempts { get; set; }
        public double RushYards { get; set; }
        public double RushAvg { get; set; }
        public double RushTD { get; set; }
        public double Plays { get; set; }
        public double TotalYards { get; set; }
        public double PassFirsts { get; set; }
        public double RushFirsts { get; set; }
        public double PenaltyFirsts { get; set; }
        public double TotalFirsts { get; set; }
        public double Penalties { get; set; }
        public double PenaltyYards { get; set; }
        public double Fumbles { get; set; }
        public double Interceptions { get; set; }
        public double TotalTO { get; set; }

        public Stats()
        {
        }

        public Stats(IXLRangeRow statRow)
        {
            //Index 1 = Rank which is is useless
            //Index 2 = School which we already know
            Games = int.Parse(statRow.Cell(3).Value.ToString());
            Points = double.Parse(statRow.Cell(4).Value.ToString());
            PassCompletions = double.Parse(statRow.Cell(5).Value.ToString());
            PassAttempts = double.Parse(statRow.Cell(6).Value.ToString());
            PassPercent = double.Parse(statRow.Cell(7).Value.ToString());
            PassYards = double.Parse(statRow.Cell(8).Value.ToString());
            PassTD = double.Parse(statRow.Cell(9).Value.ToString());
            RushAttempts = double.Parse(statRow.Cell(10).Value.ToString());
            RushYards = double.Parse(statRow.Cell(11).Value.ToString());
            RushAvg = double.Parse(statRow.Cell(12).Value.ToString());
            RushTD = double.Parse(statRow.Cell(13).Value.ToString());
            Plays = double.Parse(statRow.Cell(14).Value.ToString());
            TotalYards = double.Parse(statRow.Cell(15).Value.ToString());
            //Index 16 = Total Off/Def Avg = TotalYards/Plays
            PassFirsts = double.Parse(statRow.Cell(17).Value.ToString());
            RushFirsts = double.Parse(statRow.Cell(18).Value.ToString());
            PenaltyFirsts = double.Parse(statRow.Cell(19).Value.ToString());
            TotalFirsts = double.Parse(statRow.Cell(20).Value.ToString());
            Penalties = double.Parse(statRow.Cell(21).Value.ToString());
            PenaltyYards = double.Parse(statRow.Cell(22).Value.ToString());
            Fumbles = double.Parse(statRow.Cell(23).Value.ToString());
            Interceptions = double.Parse(statRow.Cell(24).Value.ToString());
            TotalTO = double.Parse(statRow.Cell(25).Value.ToString());
        }

        public Stats (string check)
        {
            if (check.Equals("blank"))
            {
                //Index 1 = Rank which is is useless
                //Index 2 = School which we already know
                Games = 0;
                Points = 0;
                PassCompletions = 0;
                PassAttempts = 0;
                PassPercent = 0;
                PassYards = 0;
                PassTD = 0;
                RushAttempts = 0;
                RushYards = 0;
                RushAvg = 0;
                RushTD = 0;
                Plays = 0;
                TotalYards = 0;
                //Index 16 = Total Off/Def Avg = TotalYards/Plays
                PassFirsts = 0;
                RushFirsts = 0;
                PenaltyFirsts = 0;
                TotalFirsts = 0;
                Penalties = 0;
                PenaltyYards = 0;
                Fumbles = 0;
                Interceptions = 0;
                TotalTO = 0;
            }
        }
    }
}
