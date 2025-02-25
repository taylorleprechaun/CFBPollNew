using MediatR;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed record GetRankingsRequest : IRequest<GetRankingsResponse>
    {
        public int Season { get; init; }
        public int Week { get; init; }
    }
}
