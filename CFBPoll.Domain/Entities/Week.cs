using CFBPoll.Domain.Common;

namespace CFBPoll.Domain.Entities
{
    public class Week : BaseEntity
    {
        public string Name { get; init; }
        public int Number { get; init; }
    }
}
