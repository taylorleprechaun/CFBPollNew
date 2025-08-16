using CFBPoll.DB.DataLoader;

var options = args.Where(a => a?.StartsWith("--") == true).Select(s => s.TrimStart('-'));
if (options.Contains("help"))
{
    Console.WriteLine("CFB Poll DB Data Loader");
    Console.WriteLine("Usage: CFBPollDBDataLoader [--help] [--import]");
    Console.WriteLine("--help: Show this help message.");
    Console.WriteLine("--import: Import data from the Data directory.");
}
else if (options.Contains("import"))
{
    while (!Directory.Exists("./Data"))
    {
        Console.WriteLine("Data Directory not found: " + Path.GetFullPath("./Data"));
        Console.WriteLine("Please correct and press [ENTER] to continue.");
        Console.ReadLine();
    }

    var dataLoader = new DataLoader();
    dataLoader.Run();
}

Console.WriteLine("Press [ENTER] to finish.");
Console.ReadLine();