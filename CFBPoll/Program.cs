using CFBPoll.Data.Console;
using CFBPoll.DTOs.Enums;
using CFBPoll.DTOs.Rating;
using CFBPoll.System.Data.SpreadsheetData;
using CFBPoll.System.Data.Text;
using CFBPoll.System.Modules.Default;
using CFBPoll.System.Modules.Factories;

var consoleData = new ConsoleData();
var spreadsheetData = new SpreadsheetData();
var textData = new TextData();

var season = consoleData.GetSeason();
var week = consoleData.GetWeek();

var cfbModule = new DefaultCFBModule();

var teamDetails = await cfbModule.GetTeamDetails(season, week);

var ratingRequest = new RatingRequest
{
    Season = season,
    TeamDetails = teamDetails,
    Week = week
};
var rater = RatingFactory.GetRatingModule(season);
var ratings = rater.RateTeams(ratingRequest);

do
{
    var runType = consoleData.GetRunType();
    switch (runType)
    {
        case RunType.Ratings:
            //Print Ratings
            textData.PrintPollTable(teamDetails, ratings);
            if (consoleData.PrintDetails(runType))
                spreadsheetData.PrintPollDetails(teamDetails, ratings);
            break;
        //case RunType.PredictGames:
        //case RunType.PredictResults:
        //case RunType.PredictGame:
        default:
            break;
    }
}
while (!consoleData.DoExit());

