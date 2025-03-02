using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed record GetArchivedRankingsResponse
    {
        public IEnumerable<RankingDetail> RankingDetails { get; init; }
    }
}
