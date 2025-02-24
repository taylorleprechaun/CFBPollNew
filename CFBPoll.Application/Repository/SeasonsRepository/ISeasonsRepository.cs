using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Repository.SeasonsRepository
{
    public interface ISeasonsRepository
    {
        /// <summary>
        /// Get all seasons.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Seasons object containing details about all the seasons.</returns>
        Task<Seasons> GetAllSeasons(CancellationToken cancellationToken);
    }
}
