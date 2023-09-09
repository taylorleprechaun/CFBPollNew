namespace CFBPollDTOs
{
    public class Season
    {
        public Statistics DefenseStatistics { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public Statistics OffenseStatistics { get; set; }
        public double OpponentStrength { get; set; }
        public double Rating { get; set; }
        public double StrengthOfSchedule { get; set; }
        public double WeightedStrengthOfSchedule { get; set; }
        public int Year { get; set; }

        public Season() { }

        public Season(Statistics defenseStats, IEnumerable<Game> games, Statistics offenseStats, double opponentStrength, double rating, double strengthOfSchedule, double weightedStrengthOfSchedule, int year)
        {
            DefenseStatistics = defenseStats;
            Games = games;
            OffenseStatistics = offenseStats;
            OpponentStrength = opponentStrength;
            Rating = rating;
            StrengthOfSchedule = strengthOfSchedule;
            WeightedStrengthOfSchedule = weightedStrengthOfSchedule;
            Year = year;
        }

        #region public methods

        /// <summary>
        /// Gets the games the team lost
        /// </summary>
        /// <param name="teamName">The team name to check who lost</param>
        /// <returns>The games the team lost</returns>
        public IEnumerable<Game> GetLosses(string teamName)
        {
            return Games.Where(g => !g.FutureGame && !WonGame(g, teamName));
        }

        /// <summary>
        /// Gets the games the team played
        /// </summary>
        /// <returns>The games the team played</returns>
        public IEnumerable<Game> GetPlayedGames()
        {
            return Games.Where(g => !g.FutureGame);
        }

        /// <summary>
        /// Gets the games the team hasn't played
        /// </summary>
        /// <returns>The games the team hasn't played</returns>
        public IEnumerable<Game> GetUnplayedGames()
        {
            return Games.Where(g => g.FutureGame);
        }

        /// <summary>
        /// Gets the games the team won
        /// </summary>
        /// <param name="teamName">The team name to check who won</param>
        /// <returns>The games the team won</returns>
        public IEnumerable<Game> GetWins(string teamName)
        {
            return Games.Where(g => !g.FutureGame && WonGame(g, teamName));
        }

        #endregion

        #region private methods

        /// <summary>
        /// Method used to evaluate the winner of a game
        /// </summary>
        /// <param name="game">The game to evaluate</param>
        /// <param name="teamName">The team to check if they won</param>
        /// <returns>If the team won a particular game</returns>
        private bool WonGame(Game game, string teamName)
        {
            return (game.HomeTeam.Equals(teamName, StringComparison.OrdinalIgnoreCase) && game.HomePoints > game.AwayPoints)
                || (game.AwayTeam.Equals(teamName, StringComparison.OrdinalIgnoreCase) && game.AwayPoints > game.HomePoints);
        }

        #endregion
    }
}
