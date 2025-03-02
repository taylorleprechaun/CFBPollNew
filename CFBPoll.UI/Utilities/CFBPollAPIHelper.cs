/* Creating this in case some day I ever extract out the CFBPoll.Application/Domain/Persistence functionality
 * into a separate, standalone API like they probably should be. For now though since I'm really only going to
 * run this code locally I'm going to interface with it directly however I'm going to do it through this helper
 * class to make separating out the code easier in the future.
 */


using CFBPoll.Application.Features.RankingsFeatures.Get;
using CFBPoll.Application.Features.SeasonsFeatures.Get;
using CFBPoll.Application.Features.WeeksFeatures.Get;
using CFBPoll.Domain.Entities;
using MediatR;

namespace CFBPoll.UI.Utilities
{
    public class CFBPollAPIHelper
    {
        private readonly IMediator _mediator;

        public CFBPollAPIHelper(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<int>> GetAvailableSeasons()
        {
            var getAllSeasonsResponse = await _mediator.Send(new GetAllSeasonsRequest());

            if (getAllSeasonsResponse == null) return new List<int>();
            return getAllSeasonsResponse.Years;
        }

        public async Task<IEnumerable<int>> GetAvailableWeeksForSeason(int season)
        {
            var getAllWeeksResponse = await _mediator.Send(new GetAllWeeksRequest() { Season = season });
            
            if (getAllWeeksResponse == null) return new List<int>();
            return getAllWeeksResponse.WeekDetails.Select(w => w.Number);
        }

        public async Task<IEnumerable<RankingDetail>> GetRankings(int season, int week, bool useArchivedRankings = true)
        {
            IEnumerable<RankingDetail> result = new List<RankingDetail>();

            if (useArchivedRankings)
            {
                var getArchivedRankingsResponse = await _mediator.Send(new GetArchivedRankingsRequest() { Season = season, Week = week });
                if (getArchivedRankingsResponse != null)
                    result = getArchivedRankingsResponse.RankingDetails;
            }
            else
            {
                var getRankingsResponse = await _mediator.Send(new GetRankingsRequest() { Season = season, Week = week });
                if (getRankingsResponse != null)
                    result = getRankingsResponse.RankingDetails;
            }
            return result;
        }
    }
}
