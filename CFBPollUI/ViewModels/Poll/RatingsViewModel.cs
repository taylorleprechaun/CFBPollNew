using CFBPollDTOs;
using CFBPollUI.ViewModels.Shared.Grid.Helpers;

namespace CFBPollUI.ViewModels.Poll
{
    public class RatingsViewModel
    {
        public IEnumerable<RatingDetails> Data { get; set; }
        public IEnumerable<DynamicColumn> DynamicColumns { get; set; }
        public SortCriteria Sorting { get; set; }

        public RatingsViewModel() 
        { 
            Data = new List<RatingDetails>(); 
        }

        public RatingsViewModel(IEnumerable<RatingDetails> ratingDetails, IEnumerable<DynamicColumn> dynamicColumns, SortCriteria sortCriteria) 
        {  
            Data = ratingDetails; 
            DynamicColumns = dynamicColumns;
            Sorting = sortCriteria;
        }
    }
}
