namespace CFBPoll.UI.ViewModels.Poll
{
    public class CFBPollViewModel
    {
        public RatingsViewModel Ratings { get; set; }
        public SelectionsViewModel Selections { get; set; }

        public CFBPollViewModel()
        {
            Ratings = new RatingsViewModel();
            Selections = new SelectionsViewModel();
        }
    }
}
