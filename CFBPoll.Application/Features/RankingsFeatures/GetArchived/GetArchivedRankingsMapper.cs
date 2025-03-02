using AutoMapper;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.RankingsFeatures.Get
{
    public sealed class GetArchivedRankingsMapper : Profile
    {
        public GetArchivedRankingsMapper()
        {
            CreateMap<Rankings, GetArchivedRankingsResponse>();
        }
    }
}
