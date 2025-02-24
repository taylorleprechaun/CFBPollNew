using CFBPoll.Domain.Entities;
using CFBPoll.UI.Models;
using CFBPoll.UI.ViewModels.Shared.Grid.Helpers;

namespace CFBPoll.UI.ViewModels.Poll
{
    public class RatingsViewModel
    {
        public IEnumerable<Rating> Data { get; set; }
        public IEnumerable<DynamicColumn> DynamicColumns { get; set; }
        public SortCriteria Sorting { get; set; }

        public RatingsViewModel() 
        {
            Data = new List<Rating>();
            DynamicColumns = new List<DynamicColumn>();
            Sorting = new SortCriteria();
        }
    }
}
