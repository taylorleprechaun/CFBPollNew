using System;
using System.Collections.Generic;

namespace CFBPollNew
{
    class TeamSchedule
    {
        public List<Game> Schedule { get; set; }
        public double Wins { get; set; }
        public double Losses { get; set; }
        public double GamesPlayed { get; set; }
        public double Strength { get; set; }
        public double OpponentStrength { get; set; }
        public double WeightedStrength { get; set; }

        public TeamSchedule()
        {
            Schedule = new List<Game>();
            Wins = 0;
            Losses = 0;
            GamesPlayed = 0;
        }

        public void Add(Game game)
        {
            Schedule.Add(game);
            
            GamesPlayed++;
            
            if (game.Result)
            {
                Wins++;
            }
            else
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
            Console.Write("(" + Wins + " - " + Losses + ")");
        }
    }
}
