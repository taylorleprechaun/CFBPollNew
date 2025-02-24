using CFBPoll.Calculations.Factories;
using CFBPoll.Data.Modules;
using CFBPoll.Utilities;
using CFBPollDTOs;
using CFBPollUI.ViewModels.Poll;
using CFBPollUI.ViewModels.Shared.Grid;
using CFBPollUI.ViewModels.Shared.Grid.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CFBPollUI.Controllers
{
    public class PollController : BaseController
    {
        private readonly FileSystemDataModule _fileSystemDataModule;
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;
        private SortCriteria DefaultSortCriteria { get { return new SortCriteria() { SortColumn = "Rating", SortDirection = "Desc" }; } }
        private int PageSize { get { return 150; } }

        public PollController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) 
        {
            _fileSystemDataModule = new FileSystemDataModule(_config);
        }


        #region Public Methods

        public IActionResult Index()
        {
            //Default to current season
            var seasons = _fileSystemDataModule.GetSeasons();
            var currentSeason = seasons.OrderBy(s => s).LastOrDefault();
            var weeks = _fileSystemDataModule.GetWeeks(currentSeason);
            var currentWeek = weeks.OrderBy(w => w).LastOrDefault();

            //Rating details
            var ratingDetails = GetRatingDetails(currentSeason, currentWeek);

            //Rating grid columns
            var dynamicColumns = ConfigureGridColumns();

            var cfbPollVM = new CFBPollViewModel(ratingDetails, dynamicColumns, DefaultSortCriteria, seasons, weeks, currentSeason, currentWeek);

            return View(cfbPollVM);
        }

        [HttpGet]
        public IActionResult FillWeeks(int season)
        {
            var selectionsVM = new SelectionsViewModel(_fileSystemDataModule.GetSeasons(), _fileSystemDataModule.GetWeeks(season), selectedSeason: season);

            return PartialView("_SelectionsPartial", selectionsVM);
        }

        [HttpGet]
        public IActionResult FillRatingsGrid(int season, int week)
        {
            //Rating details
            var ratingDetails = GetRatingDetails(season, week);

            //Rating grid columns
            var dynamicColumns = ConfigureGridColumns();

            var ratingsVM = new RatingsViewModel(ratingDetails, dynamicColumns, DefaultSortCriteria);

            return PartialView("_RatingsPartial", ratingsVM);
        }

        #endregion

        #region Private Methods

        private IEnumerable<RatingDetails> GetRatingDetails(int season, int week)
        {
            //Build the dictionary of teams for the given season/week
            var teamBuilder = new TeamBuilder(_config, season, week);
            var teams = teamBuilder.BuildTeams();

            //Rate the teams
            var rater = RatingFactory.GetRatingModule(season, week);
            teams = rater.RateTeams(teams);
            
            //Return the rating details
            return rater.GetRatingDetails(teams);
        }

        private IEnumerable<DynamicColumn> ConfigureGridColumns()
        {
            var dynamicColumnsList = new List<DynamicColumn>()
            {
                //new DynamicColumn() { PropertyName = "Rank", Position = 1, Title = "", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                new DynamicColumn() { PropertyName = "TeamName", Position = 2, Title = "", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                new DynamicColumn() { PropertyName = "Rating", Position = 3, Title = "", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                //new DynamicColumn() { PropertyName = "Percent", Position = 4, Title = "", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
            };

            return dynamicColumnsList;
        }

        #endregion
    }
}