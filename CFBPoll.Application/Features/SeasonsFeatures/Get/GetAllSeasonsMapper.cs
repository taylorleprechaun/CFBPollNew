using AutoMapper;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.SeasonsFeatures.Get
{
    public sealed class GetAllSeasonsMapper : Profile
    {
        public GetAllSeasonsMapper()
        {
            CreateMap<Seasons, GetAllSeasonsResponse>();
        }
    }
}
