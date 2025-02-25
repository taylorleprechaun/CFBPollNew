using CFBPoll.Application.Features.WeeksFeatures.Get;
using CFBPoll.Application.Repository.WeeksRepository;
using CFBPoll.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CFBPoll.Persistence.Repository.WeeksRepository
{
    public class WeekRepository : IWeeksRepository
    {
        private readonly string _filesPath;

        public WeekRepository(IConfiguration config)
        {
            _filesPath = config.GetSection("AppSettings:FilesPath").Value ?? string.Empty;
        }

        public async Task<Weeks> GetAllWeeks(GetAllWeeksRequest request, CancellationToken cancellationToken)
        {
            var getWeeksTask = Task.Run(() =>
            {
                var weeks = new List<Week>();
                var newFilePath = Path.Join(_filesPath, request.Season.ToString());

                var files = Directory.GetFiles(newFilePath);
                foreach (var file in files)
                {
                    var week = file.Replace($"{newFilePath}\\", "").Replace(".xlsx", "").Substring(7);
                    var name = week;
                    if (!week.All(char.IsDigit) && week.Any(char.IsWhiteSpace))
                    {
                        var weekParts = week.Split(' ');
                        name = weekParts[1];
                        week = weekParts[0];
                    }
                    if (int.TryParse(week, out var weekInt))
                        weeks.Add(new Week()
                        {
                            Name = name,
                            Number = weekInt
                        });
                }

                return weeks;
            }, cancellationToken);
            
            var weeks = await getWeeksTask;

            return new Weeks() { WeekDetails = weeks };
        }
    }
}
