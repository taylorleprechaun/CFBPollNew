using CFBPollDTOs.Enums;

namespace CFBPollDTOs
{
    public class Game
    {
        public double AwayPoints { get; set; }
        public string AwayTeam { get; set; }
        public bool FutureGame { get; set; }
        public double HomePoints { get; set; }
        public string HomeTeam { get; set; }
        public bool NeutralSite { get; set; }
        public int Season { get; set; }
        public int Week { get; set; }

        public Game(Game game)
        {
            AwayPoints = game.AwayPoints;
            AwayTeam = game.AwayTeam;
            FutureGame = game.FutureGame;
            HomePoints = game.HomePoints;
            HomeTeam = game.HomeTeam;
            NeutralSite = game.NeutralSite;
            Season = game.Season;
            Week = game.Week;
        }

        public Game(string homeTeam, string awayTeam, double homePoints, double awayPoints, int season, int week, bool neutralSite, bool futureGame)
        {
            AwayPoints = awayPoints;
            AwayTeam = awayTeam;
            FutureGame = futureGame;
            HomePoints = homePoints;
            HomeTeam = homeTeam;
            NeutralSite = neutralSite;
            Season = season;
            Week = week;
        }
    }
}