﻿using CFBPoll.Calculations.Factories;
using CFBPoll.Data.Modules;
using CFBPoll.Utilities;
using Microsoft.Extensions.Configuration;

//Set up application settings config
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile($"appsettings.json");
configurationBuilder.AddJsonFile($"appsettings-private.json");
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

//Initialize the rating and prediction modules
var rater = new RatingFactory().GetRatingModule(season, week);
var predictor = new PredictionFactory().GetPredictionModule(season, teams);

//Running the program
do
{
    var mode = consoleDataModule.GetRunType();
    switch (mode)
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



