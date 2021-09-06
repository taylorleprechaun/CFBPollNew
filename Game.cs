using System;

namespace CFBPollNew
{
    class Game
    {
        public Team Team { get; set; }
        public Team Opponent { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        
        //True = win, False = loss
        public bool Result { get; set; }

        public Game()
        {
        }

        public Game (Team team, Team opponent, int pointsFor, int pointsAgainst)
        {
            Team = team;
            Opponent = opponent;
            PointsFor = pointsFor;
            PointsAgainst = pointsAgainst;
            Result = PointsFor > PointsAgainst;
        }

        public void Print()
        {
            Console.Write(Result ? "W - " : "L - ");
            Console.Write(Team.Name + ": " + PointsFor + " - " + PointsAgainst + " :" + Opponent.Name);
            Console.WriteLine();
        }
    }
}
