using CFBPollDTOs;
using CFBPollUI.ViewModels.Shared.Grid.Helpers;

namespace CFBPollUI.ViewModels.Poll
{
    public class CFBPollViewModel
    {
        public RatingsViewModel Ratings { get; set; }
        public SelectionsViewModel Selections { get; set; }

        public CFBPollViewModel(IEnumerable<RatingDetails> ratingDetails, IEnumerable<DynamicColumn> dynamicColumns, SortCriteria sortCriteria, IEnumerable<int> seasons, IEnumerable<int> weeks, int selectedSeason, int selectedWeek)
        {
            Ratings = new RatingsViewModel(ratingDetails, dynamicColumns, sortCriteria);
            Selections = new SelectionsViewModel(seasons, weeks, selectedSeason, selectedWeek);
        }
    }
}
