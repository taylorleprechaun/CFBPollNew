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
var cfbModule = new DefaultCFBModule();

do
{
    var season = consoleData.GetSeason();
    var isPostSeason = consoleData.IsPostseason();
    var seasonType = isPostSeason ? "Postseason" : "Regular";
    var week = isPostSeason ? 1 : consoleData.GetWeek();

    var teamDetails = await cfbModule.GetTeamDetails(season, seasonType, week);

    var ratingWeek = isPostSeason ? teamDetails?.Max(t => t.Value?.Games?.Max(g => g?.Week ?? 0) ?? 0) ?? week : week;

    var ratingRequest = new RatingRequest
    {
        Season = season,
        TeamDetails = teamDetails,
        Week = ratingWeek
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
                    spreadsheetData.PrintPollDetails(teamDetails, ratings, season, ratingWeek);
                break;
            //case RunType.PredictGames:
            //case RunType.PredictResults:
            //case RunType.PredictGame:
            default:
                break;
        }
    }
    while (consoleData.RunAnotherType());
}
while (consoleData.RunAgain());