namespace CFBPollUI.ViewModels.Poll
{
    public class CFBPollViewModel
    {
        public SelectionsViewModel Selections { get; set; }

        public CFBPollViewModel(IEnumerable<int> seasons, IEnumerable<int> weeks, int? selectedSeason = null, int? selectedWeek = null)
        {
            Selections = new SelectionsViewModel(seasons, weeks, selectedSeason: selectedSeason, selectedWeek: selectedWeek);
        }
    }
}
