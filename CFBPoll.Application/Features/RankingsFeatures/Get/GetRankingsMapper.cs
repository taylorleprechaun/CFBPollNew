using AutoMapper;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed class GetRankingsMapper : Profile
    {
        public GetRankingsMapper()
        {
            CreateMap<Rankings, GetRankingsResponse>();
        }
    }
}
