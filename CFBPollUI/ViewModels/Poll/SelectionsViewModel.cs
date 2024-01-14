using CFBPollDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CFBPollUI.ViewModels.Poll
{
    public class SelectionsViewModel
    {
        public IEnumerable<SelectListItem> Seasons { get; set; }
        public int SelectedSeason { get; set; }
        public int SelectedWeek { get; set; }
        public IEnumerable<SelectListItem> Weeks { get; set; }

        public SelectionsViewModel(IEnumerable<int> seasons, IEnumerable<int> weeks, int? selectedSeason = null, int? selectedWeek = null)
        {
            var seasonsList = new List<SelectListItem>();
            foreach (int season in seasons)
            {
                var selected = season.Equals(selectedSeason);
                seasonsList.Add(new SelectListItem()
                {
                    Text = season.ToString(),
                    Value = season.ToString(),
                    Selected = selected
                });
            }
            Seasons = seasonsList;
            SelectedSeason = (int)(selectedSeason == null ? 0 : selectedSeason);

            var weeksList = new List<SelectListItem>();
            foreach (int week in weeks)
            {
                var selected = week.Equals(selectedWeek);
                weeksList.Add(new SelectListItem()
                {
                    Text = week.ToString(),
                    Value = week.ToString(),
                    Selected = selected
                });
            }
            Weeks = weeksList;
            SelectedWeek = (int)(selectedWeek == null ? 0 : selectedWeek);
        }
    }
}
