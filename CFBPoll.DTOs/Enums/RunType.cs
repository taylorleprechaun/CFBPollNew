using System.ComponentModel;

namespace CFBPoll.DTOs.Enums
{
    public enum RunType
    {
        [Description("None")]
        None = 0,
        [Description("Ratings")]
        Ratings = 1,
        //[Description("Game Predictions")]
        //PredictGames = 2,
        //[Description("Prediction Results")]
        //PredictResults = 3,
        //[Description("Predict Individual Game")]
        //PredictGame = 4
        [Description("Scenarios")]
        Scenarios = 5
    }
}