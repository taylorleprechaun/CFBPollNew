using CFBPoll.Domain.Common;

namespace CFBPoll.Domain.Entities
{
    public class Rankings : BaseEntity
    {
        public IEnumerable<RankingDetail> RankingDetails { get; init; }
    }
}
