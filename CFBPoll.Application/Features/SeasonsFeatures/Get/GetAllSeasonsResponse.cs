namespace CFBPoll.Application.Features.SeasonsFeatures.Get
{
    public sealed record GetAllSeasonsResponse
    {
        public IEnumerable<int> Years { get; init; }
    }
}
