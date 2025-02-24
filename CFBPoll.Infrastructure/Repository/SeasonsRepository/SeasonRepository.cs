using CFBPoll.Application.Repository.SeasonsRepository;
using CFBPoll.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CFBPoll.Persistence.Repository.SeasonsRepository
{
    public class SeasonRepository : ISeasonsRepository
    {
        private readonly string _filesPath;

        public SeasonRepository(IConfiguration config)
        {
            _filesPath = config.GetSection("AppSettings:FilesPath").Value ?? string.Empty;
        }

        public async Task<Seasons> GetAllSeasons(CancellationToken cancellationToken)
        {
            var GetSeasonsTask = Task.Run(() => {
                var seasons = new List<int>();

                var files = Directory.GetDirectories(_filesPath);
                foreach (var file in files)
                {
                    var season = file[^4..];
                    if (int.TryParse(season, out var seasonNumber))
                    {
                        seasons.Add(seasonNumber);
                    }
                }

                return seasons;
            }, cancellationToken);
            var seasons = await GetSeasonsTask;

            return new Seasons() { Years = seasons };
        }
    }
}
