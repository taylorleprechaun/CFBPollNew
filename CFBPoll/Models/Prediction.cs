using CFBPoll.Enums;
using CFBPoll.Models;

namespace CFBPollNew.Models
{
    class Prediction
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double HomePoints { get; set; }
        public double AwayPoints { get; set; }
        public Location Location { get; set; }
        public int Week { get; set; }
        public double Spread { get; set; }
        public double OverUnder { get; set; }

        public Prediction(string homeTeam, string awayTeam, double homePoints, double awayPoints, Location location, int week, double spread, double overUnder)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomePoints = homePoints;
            AwayPoints = awayPoints;
            Location = location;
            Week = week;
            Spread = spread;
            OverUnder = overUnder;
        }

        /// <summary>
        /// Checks the result of an Over/Under prediction after the game has been played
        /// </summary>
        /// <param name="game">The game that was predicted for</param>
        /// <returns>Over if the combined points is greater than the betting Over/Under. Under if it is less. Push if it matches</returns>
        public OverUnder CheckOverUnder(Game game)
        {
            var totalPoints = game.PointsFor + game.PointsAgainst;
            return totalPoints > OverUnder 
                ? CFBPoll.Enums.OverUnder.Over
                : totalPoints == OverUnder
                    ? CFBPoll.Enums.OverUnder.Push
                    : CFBPoll.Enums.OverUnder.Under;
        }

        /// <summary>
        /// Predicts the Over/Under result for a game
        /// </summary>
        /// <returns>Over if the combined points is greater than or equal to the betting Over/Under. Under if it is less.</returns>
        public OverUnder PredictOverUnder()
        {
            var predictedTotalPoints = HomePoints + AwayPoints;
            return predictedTotalPoints >= OverUnder
                ? CFBPoll.Enums.OverUnder.Over
                : CFBPoll.Enums.OverUnder.Under;
        }

        /// <summary>
        /// Checks the result of a Spread prediction after the game has been played
        /// </summary>
        /// <param name="game">The game that was predicted for</param>
        /// <returns>The name of the team that beat the spread</returns>
        public string CheckSpread(Game game)
        {
            return (game.PointsFor + Spread) > game.PointsAgainst
                ? game.TeamName
                : game.OpponentName;
        }

        /// <summary>
        /// Predicts the Spread result for a game
        /// </summary>
        /// <returns>The team predicted to beat the spread</returns>
        public string PredictSpread()
        {
            return (HomePoints + Spread) > AwayPoints
                ? HomeTeam
                : AwayTeam;
        }

        /// <summary>
        /// Checks the result of a Winner prediction after the game has been played
        /// </summary>
        /// <param name="game">The game that was predicted for</param>
        /// <returns>The team that won the game</returns>
        public string CheckWinner(Game game)
        {
            return game.PointsFor > game.PointsAgainst
                ? game.TeamName
                : game.OpponentName;
        }

        /// <summary>
        /// Checks the result of a Winner prediction after the game has been played
        /// </summary>
        /// <param name="game">The game that was predicted for</param>
        /// <returns>The team that won the game</returns>
        public string PredictWinner()
        {
            return HomePoints > AwayPoints
                ? HomeTeam
                : AwayTeam;
        }
    }
}
