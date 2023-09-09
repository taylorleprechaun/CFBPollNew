using CFBPoll.Calculations;
using CFBPoll.Data.Console;
using CFBPoll.Data.Excel;
using CFBPoll.Data.Text;
using CFBPoll.Utilities;
using Microsoft.Extensions.Configuration;

//Set up application settings config
var configurationBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
var config = configurationBuilder.Build();

//Initialize name corrector
var nameCorrector = new NameCorrector();

//Set up data modules
var textDataModule = new TextDataModule(config, nameCorrector);
var excelDataModule = new ExcelDataModule(config, nameCorrector);
var consoleDataModule = new ConsoleDataModule(config);

//Program startup needs the season and week
var season = consoleDataModule.GetSeason();
var week = consoleDataModule.GetWeek(season);

//Build the dictionary of teams
var teamBuilder = new TeamBuilder(config, season, week);
var teams = teamBuilder.BuildTeams();

//Initialize the rater and predictor
var rater = new Rater(season, week);
var predictor = new Predictor(season, teams);

//Mode
while (true)
{
    var mode = consoleDataModule.GetRunType();
    switch(mode)
    {
        case "1":
            //Print Ratings
            teams = rater.RateTeams(teams);
            textDataModule.PrintPollTable(teams, season);
            excelDataModule.PrintPollDetails(teams, season);
            break;
        case "2":
            //Print Predictions
            var predictions = predictor.PredictGames();
            textDataModule.PrintPredictionsTable(predictions);
            excelDataModule.PrintPredictionDetails(predictions);
            break;
        case "3":
            //Specific Predictions
            while (true)
            {
                //Get user input for a game to predict and predict it
                var gameToPredict = consoleDataModule.GetGameToPredict(teams, season);
                var predictedGame = predictor.PredictSpecificGame(gameToPredict);
                consoleDataModule.PrintGame(predictedGame);
                //Go again?
                if (!consoleDataModule.PredictAgain())
                    break;
            }
            break;
        default:
            break;
    }

    //Go again?
    if (consoleDataModule.DoExit())
        break;
    else
        continue;
}



