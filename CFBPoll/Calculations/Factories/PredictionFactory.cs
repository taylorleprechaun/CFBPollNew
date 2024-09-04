using CFBPoll.Calculations.Interfaces;
using CFBPoll.Calculations.Modules;
using CFBPollDTOs;

namespace CFBPoll.Calculations.Factories
{
    public class PredictionFactory
    {
        /// <summary>
        /// Gets the prediction module for the program through an interface
        /// </summary>
        /// <param name="season">The season for the rating module</param>
        /// <param name="teams">The teams to make predictions for</param>
        /// <returns>A module that implements the IPrediction interface</returns>
        public static IPrediction GetPredictionModule(int season, IDictionary<string, Team> teams)
        {
            //No plans for it but if for some reason in the future I want to switch to a new/different prediction module
            //then I'll have to flesh out this code to switch depending on whatever conditions I choose. For now we just
            //need to return the only existing module that implements IPrediction
            return new PredictionModule(season, teams);
        }
    }
}
