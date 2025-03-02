using CFBPoll.Application.Features.RankingsFeatures.Get;
using CFBPoll.Application.Repository.RankingsRepository;
using CFBPoll.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace CFBPoll.Persistence.Repository.RankingsRepository
{
    public class RankingRepository : IRankingsRepository
    {
        private readonly string _filesPath;
        public RankingRepository(IConfiguration config)
        {
            _filesPath = config.GetSection("AppSettings:RankingsPath").Value ?? string.Empty;
        }

        #region Public Methods

        public async Task<Rankings> GetRankings(GetArchivedRankingsRequest request, CancellationToken cancellationToken)
        {
            var rankingFile = await GetRankingFile(request, cancellationToken);
            if (string.IsNullOrEmpty(rankingFile)) return new Rankings() { RankingDetails = new List<RankingDetail>() };

            var rankings = await BuildRankings(rankingFile, cancellationToken);
            if (rankings == null) return new Rankings() { RankingDetails = new List<RankingDetail>() };

            return rankings;
        }

        public async Task<Rankings> GetRankings(GetRankingsRequest request, CancellationToken cancellationToken)
        {
            //TODO: Pull data from xlsx files for stats/scores and assemble team info to dynamically calculate ratings
            return new Rankings();
        }

        #endregion

        #region Private Methods

        private async Task<Rankings> BuildRankings(string rankingFile, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(rankingFile)) return new Rankings() { RankingDetails = new List<RankingDetail>() };

            var rankingDetails = new ConcurrentBag<RankingDetail>();
            var lines = await Task.Run(() => File.ReadAllLines(rankingFile), cancellationToken);
            Parallel.ForEach(lines, line =>
            {
                var lineParts = line.Split('|');
                if (!int.TryParse(lineParts[0], out var ranking)) return;
                decimal? strengthOfSchedule = lineParts.Length >= 5 && decimal.TryParse(lineParts[4], out var sos) ? sos : null;
                int? strengthOfScheduleRank = lineParts.Length >= 5 && int.TryParse(lineParts[5], out var sosRank) ? sosRank : null;

                var rankingDetail = new RankingDetail()
                {
                    Rank = ranking,
                    Rating = decimal.Parse(lineParts[2]),
                    Record = lineParts[3],
                    StrengthOfSchedule = strengthOfSchedule,
                    StrengthOfScheduleRank = strengthOfScheduleRank,
                    TeamName = lineParts[1],
                };
                rankingDetails.Add(rankingDetail);
            });

            return new Rankings() { RankingDetails = rankingDetails };
        }

        private async Task<string> GetRankingFile(GetArchivedRankingsRequest request, CancellationToken cancellationToken)
        {
            var rankingFileName = string.Empty;
            var newFilePath = Path.Join(_filesPath, request.Season.ToString());

            var files = await Task.Run(() => Directory.GetFiles(newFilePath), cancellationToken);
            foreach (var file in files)
            {
                if (!file.EndsWith(".md")) continue;

                var week = file.Replace($"{newFilePath}\\", "").Substring(10, 2);
                if (int.TryParse(week, out var weekInt) && weekInt.Equals(request.Week))
                {
                    rankingFileName = file;
                    break;
                }
            }

            return rankingFileName;
        }

        #endregion
    }
}
