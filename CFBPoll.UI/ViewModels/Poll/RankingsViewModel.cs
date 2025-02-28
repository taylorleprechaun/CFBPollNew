using CFBPoll.Domain.Entities;
using CFBPoll.UI.Models;
using CFBPoll.UI.ViewModels.Shared.Grid.Helpers;

namespace CFBPoll.UI.ViewModels.Poll
{
    public class RankingsViewModel
    {
        public IEnumerable<DynamicColumn> DynamicColumns { get; init; }
        public IEnumerable<RankingDetail> RankingDetails { get; init; }
        public SortCriteria Sorting { get; init; }

        public RankingsViewModel() 
        {
            DynamicColumns = new List<DynamicColumn>();
            RankingDetails = new List<RankingDetail>();
            Sorting = new SortCriteria();
        }

        public RankingsViewModel(IEnumerable<RankingDetail> rankingDetails, IEnumerable<DynamicColumn> dynamicColumns, SortCriteria sorting)
        {
            DynamicColumns = dynamicColumns;
            RankingDetails = rankingDetails;
            Sorting = sorting;
        }
    }
}
