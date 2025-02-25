using CFBPoll.Domain.Entities;
using CFBPoll.UI.Models;
using CFBPoll.UI.ViewModels.Shared.Grid.Helpers;

namespace CFBPoll.UI.ViewModels.Poll
{
    public class RankingsViewModel
    {
        public IEnumerable<RankingDetail> RankingDetails { get; init; }
        public IEnumerable<DynamicColumn> DynamicColumns { get; init; }
        public SortCriteria Sorting { get; init; }

        public RankingsViewModel() 
        {
            RankingDetails = new List<RankingDetail>();
            DynamicColumns = new List<DynamicColumn>();
            Sorting = new SortCriteria();
        }

        public RankingsViewModel(IEnumerable<RankingDetail> rankingDetails, IEnumerable<DynamicColumn> dynamicColumns, SortCriteria sorting)
        {
            RankingDetails = rankingDetails;
            DynamicColumns = dynamicColumns;
            Sorting = sorting;
        }
    }
}
