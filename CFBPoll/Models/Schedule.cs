using System;
using System.Collections.Generic;

namespace CFBPoll.Models
{
    class TeamSchedule
    {
        public List<Game> Schedule { get; set; }
        public double Wins { get; set; }
        public double Losses { get; set; }
        public double Games { get; set; }
        public double Strength { get; set; }
        public double OpponentStrength { get; set; }
        public double WeightedStrength { get; set; }

        public TeamSchedule()
        {
            Schedule = new List<Game>();
            Wins = 0;
            Losses = 0;
            Games = 0;
        }

        public void Add(Game game)
        {
            Schedule.Add(game);
            
            Games++;
            
            if (game.Result.Equals(ResultEnum.Win))
            {
                Wins++;
            }
            else if (game.Result.Equals(ResultEnum.Loss))
            {
                Losses++;
            }
        }

        public void PrintSchedule()
        {
            foreach (var game in Schedule)
            {
                game.Print();
            }
        }

        public void PrintRecord()
        {
            Console.Write("(" + Wins + " - " + Losses + ")\n");
        }
    }
}
