using MediatR;

namespace CFBPoll.Application.Features.SeasonsFeatures.Get
{
    public sealed record GetAllSeasonsRequest : IRequest<GetAllSeasonsResponse>;

}
