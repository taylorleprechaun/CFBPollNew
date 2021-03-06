using System;

namespace CFBPollNew
{
    class Game
    {
        public Team Team { get; set; }
        public Team Opponent { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public LocationEnum Location { get; set; }
        public int Week { get; set; }
        public ResultEnum Result { get; set; }
        public bool FutureGame { get; set; }

        public Game()
        {
        }

        public Game(Team team, Team opponent, int pointsFor, int pointsAgainst, int week, LocationEnum location)
        {
            Team = team;
            Opponent = opponent;
            PointsFor = pointsFor;
            PointsAgainst = pointsAgainst;
            Location = location;
            Week = week;

            //If it's 0 - 0 it's a future game
            if (PointsFor == 0 && PointsAgainst == 0)
            {
                FutureGame = true;
                Result = ResultEnum.Future;
            }
            else
            {
                Result = PointsFor > PointsAgainst ? ResultEnum.Win : ResultEnum.Loss;
            }
                
        }

        public void Print()
        {
            Console.Write(Result + " - ");
            Console.Write(Team.Name + ": " + PointsFor + " - " + PointsAgainst + " :" + Opponent.Name);
            Console.WriteLine();
        }
    }

    public enum ResultEnum
    {
        Win,
        Loss,
        Future
    }

    public enum LocationEnum
    {
        Home,
        Road,
        Neutral
    }
}
