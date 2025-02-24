using AutoMapper;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.WeeksFeatures.Get
{
    public sealed class GetAllWeeksMapper : Profile
    {
        public GetAllWeeksMapper()
        {
            CreateMap<Weeks, GetAllWeeksResponse>();
        }
    }
}
