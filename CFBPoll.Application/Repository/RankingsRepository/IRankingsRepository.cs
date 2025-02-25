using CFBPoll.Application.Features.RankingsFeatures.Get;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Repository.RankingsRepository
{
    public interface IRankingsRepository
    {
        Task<Rankings> GetRankings(GetRankingsRequest request, CancellationToken cancellationToken);
    }
}
