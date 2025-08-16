namespace CFBPoll.DTOs
{
    public class Season
    {
        public IEnumerable<Game> Games { get; set; }
        public RatingDetails RatingDetails { get; set; }
        public int Year { get; set; }

        public Season() { }

        /// <summary>
        /// Constructor for a Season for a team that hasn't played any games yet
        /// </summary>
        /// <param name="teamName">The name of the team</param>
        /// <param name="year">The year of the season</param>
        public Season(string teamName, int year) 
        { 
            Games = new List<Game>();
            RatingDetails = new RatingDetails()
            {
                DefenseStatistics = new Statistics(),
                OffenseStatistics = new Statistics(),
                Rating = 0,
                StrengthOfSchedule = 0,
                TeamName = teamName,
                WeightedStrengthOfSchedule = 0
            };
            Year = year;
        }

        /// <summary>
        /// Constructor for a Season for a team that has played a game and has all the relevant statistics
        /// </summary>
        /// <param name="defenseStats">The defensive stats</param>
        /// <param name="games">The games on their schedule</param>
        /// <param name="offenseStats">The offensive stats</param>
        /// <param name="rating">The team's rating</param>
        /// <param name="strengthOfSchedule">The strength of schedule</param>
        /// <param name="teamName">The name of the team</param>
        /// <param name="weightedStrengthOfSchedule">The weighted strength of schedule</param>
        /// <param name="year">The year of the season</param>
        public Season(Statistics defenseStats, IEnumerable<Game> games, Statistics offenseStats, double rating, double strengthOfSchedule, string teamName, double weightedStrengthOfSchedule, int year)
        {
            Games = games;
            RatingDetails = new RatingDetails()
            {
                DefenseStatistics = defenseStats,
                OffenseStatistics = offenseStats,
                Rating = rating,
                StrengthOfSchedule = strengthOfSchedule,
                TeamName = teamName,
                WeightedStrengthOfSchedule = weightedStrengthOfSchedule
            };
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
