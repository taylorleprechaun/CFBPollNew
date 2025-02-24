using MediatR;

namespace CFBPoll.Application.Features.WeeksFeatures.Get
{
    public sealed record GetAllWeeksRequest : IRequest<GetAllWeeksResponse>
    {
        public int Season { get; init; }
    }
}
