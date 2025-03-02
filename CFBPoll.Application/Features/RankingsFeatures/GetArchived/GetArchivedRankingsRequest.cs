using MediatR;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed record GetArchivedRankingsRequest : IRequest<GetArchivedRankingsResponse>
    {
        public int Season { get; init; }
        public int Week { get; init; }
    }
}
