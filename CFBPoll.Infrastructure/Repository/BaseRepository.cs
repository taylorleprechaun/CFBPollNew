using CFBPoll.Application.Repository;
using CFBPoll.Domain.Common;

namespace CFBPoll.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
    }
}
