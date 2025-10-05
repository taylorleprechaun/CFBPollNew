using CFBPoll.System.Modules.Default;
using Microsoft.Extensions.Configuration;

//Set up application settings config
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile($"appsettings.json");
configurationBuilder.AddJsonFile($"appsettings-private.json");
var config = configurationBuilder.Build();

var season = 2025;
var cfbModule = new DefaultCFBModule();

var teams = await cfbModule.GetTeams(season);

var games = await cfbModule.GetGames(season);

var teamStats = await cfbModule.GetTeamStats(season);

var gameStats = await cfbModule.GetGameStats(season);

//foreach (var team in teams.Values)
//{
//    if (team == null || string.IsNullOrEmpty(team.School))
//        continue;

//    games.TryGetValue(team.School, out var teamGames);
//    Console.WriteLine($"{team.School} - Games: {teamGames?.Count() ?? 0}");

//    if (teamGames == null || !teamGames.Any())
//        continue;

//    foreach (var game in teamGames)
//    {
//        if (game == null)
//            continue;

//        Console.WriteLine($"\tWeek {game.Week}: {game.AwayTeam} {(game.NeutralSite ?? false ? "vs" : "at")} {game.HomeTeam}");
//        Console.WriteLine($"\t\t{game.AwayTeam} - {game.AwayPoints}");
//        Console.WriteLine($"\t\t{game.HomeTeam} - {game.HomePoints}");
//    }
//}
