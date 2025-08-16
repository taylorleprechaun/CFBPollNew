using CFBPoll.Data.Console;
using CFBPoll.DTOs.Enums;
using CFBPoll.System.Data.Modules;
using CFBPoll.System.Data.Text;
using CFBPoll.System.Modules.Factories;
using CFBPoll.System.Utilities;
using Microsoft.Extensions.Configuration;

//Set up application settings config
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile($"appsettings.json");
configurationBuilder.AddJsonFile($"appsettings-private.json");
var config = configurationBuilder.Build();

//Initialize name corrector
var nameCorrector = new NameCorrector();

//Set up data modules
var textDataModule = new TextData(config, nameCorrector);
var excelDataModule = new ExcelData(config, nameCorrector);
var consoleDataModule = new ConsoleData(config);

//Program startup needs the season and week
var season = consoleDataModule.GetSeason();
var week = consoleDataModule.GetWeek(season);

//Build the dictionary of teams
var teamBuilder = new TeamBuilder(config, season, week);
var teams = teamBuilder.BuildTeams();

//Initialize the rating and prediction modules
var rater = RatingFactory.GetRatingModule(season, week);
teams = rater.RateTeams(teams);
var predictor = PredictionFactory.GetPredictionModule(season, teams);

//Running the program
do
{
    var runType = consoleDataModule.GetRunType();
    switch (runType)
    {
        case RunType.Ratings:
            //Print Ratings
            textDataModule.PrintPollTable(teams, season);
            if (consoleDataModule.PrintDetails(runType))
                excelDataModule.PrintPollDetails(teams, season);
            break;
        case RunType.PredictGames:
            //Print Predictions
            var predictions = predictor.PredictGames();
            textDataModule.PrintPredictionsTable(predictions);
            if (consoleDataModule.PrintDetails(runType))
                excelDataModule.PrintPredictionDetails(predictions);
            break;
        case RunType.PredictResults:
            //Get the predictions we made the previous week and print them
            var predictedGames = textDataModule.GetPredictions(season, week);
            textDataModule.PrintPredictionsResultsTable(predictedGames, teams, season);
            break;
        case RunType.PredictGame:
            //Specific Predictions
            do
            {
                //Get user input for a game to predict and predict it
                var gameToPredict = consoleDataModule.GetGameToPredict(teams, season);
                var predictedGame = predictor.PredictSpecificGame(gameToPredict);
                consoleDataModule.PrintGame(predictedGame);
            }
            while (consoleDataModule.PredictAgain());
            break;
        default:
            break;
    }
}
while (!consoleDataModule.DoExit());



