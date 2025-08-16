using CFBPoll.DTOs;

namespace CFBPoll.System.Modules.Interfaces
{
    public interface IPredictionModule
    {
        /// <summary>
        /// Predicts the result of a specific game
        /// </summary>
        /// <param name="game">The game to predict</param>
        /// <returns>A predicted game</returns>
        public Game PredictSpecificGame(Game game);

        /// <summary>
        /// Predicts the result of the next week of unplayed games
        /// </summary>
        /// <returns>A list of predicted games</returns>
        public IEnumerable<Game> PredictGames();
    }
}
