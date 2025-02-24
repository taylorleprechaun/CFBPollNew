using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Features.WeeksFeatures.Get
{
    public sealed record GetAllWeeksResponse
    {
        public IEnumerable<Week> WeekDetails { get; init; }
    }
}
