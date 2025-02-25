namespace CFBPoll.UI.ViewModels.Poll
{
    public class CFBPollViewModel
    {
        public RankingsViewModel Rankings { get; set; }
        public SelectionsViewModel Selections { get; set; }

        public CFBPollViewModel()
        {
            Rankings = new RankingsViewModel();
            Selections = new SelectionsViewModel();
        }
    }
}
