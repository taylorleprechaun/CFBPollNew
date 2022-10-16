using CFBPoll.Enums;
using System;

namespace CFBPoll.Models
{
    class Game
    {
        public Team Team { get; set; }
        public string TeamName { get; set; }
        public Team Opponent { get; set; }
        public string OpponentName { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public Location Location { get; set; }
        public int Week { get; set; }
        public Result Result { get; set; }
        public bool FutureGame { get; set; }

        public Game()
        {
        }

        public Game(Team team, Team opponent, int pointsFor, int pointsAgainst, int week, Location location)
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
                Result = Result.Future;
            }
            else
            {
                Result = PointsFor > PointsAgainst ? Result.Win : Result.Loss;
            }
        }

        public Game(string teamName, string opponentName, int pointsFor, int pointsAgainst, int week, Location location)
        {
            TeamName = teamName;
            OpponentName = opponentName;
            PointsFor = pointsFor;
            PointsAgainst = pointsAgainst;
            Location = location;
            Week = week;

            //If it's 0 - 0 it's a future game
            if (PointsFor == 0 && PointsAgainst == 0)
            {
                FutureGame = true;
                Result = Result.Future;
            }
            else
            {
                Result = PointsFor > PointsAgainst ? Result.Win : Result.Loss;
            }
        }

        public void Print()
        {
            Console.Write(Result + " - ");
            Console.Write((Team != null ? Team.Name : TeamName) + ": " + PointsFor + " - " + PointsAgainst + " :" + (Opponent != null ? Opponent.Name : OpponentName));
            Console.WriteLine();
        }
    }
}
