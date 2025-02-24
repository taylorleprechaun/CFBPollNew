using CFBPoll.Domain.Common;

namespace CFBPoll.Domain.Entities
{
    public class Seasons : BaseEntity
    {
        public IEnumerable<int> Years { get; init; }
    }
}
