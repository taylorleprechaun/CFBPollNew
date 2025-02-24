using CFBPoll.Application.Features.WeeksFeatures.Get;
using CFBPoll.Domain.Entities;

namespace CFBPoll.Application.Repository.WeeksRepository
{
    public interface IWeeksRepository
    {
        /// <summary>
        /// Get all weeks for a given GetAllWeeksRequest.
        /// </summary>
        /// <param name="request">The request to get all weeks for.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Weeks object containing details about all the weeks for the request data.</returns>
        Task<Weeks> GetAllWeeks(GetAllWeeksRequest request, CancellationToken cancellationToken);
    }
}
