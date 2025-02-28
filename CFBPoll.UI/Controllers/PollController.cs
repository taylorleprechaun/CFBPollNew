using CFBPoll.UI.Controllers.Base;
using CFBPoll.UI.Models;
using CFBPoll.UI.ViewModels.Poll;
using CFBPoll.UI.ViewModels.Shared.Grid.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CFBPoll.UI.Controllers
{
    public class PollController : BaseController
    {
        private SortCriteria DefaultSortCriteria { get { return new SortCriteria() { SortColumn = "Rank", SortDirection = "Desc" }; } }
        public PollController(IMediator mediator) : base(mediator) { }

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            IEnumerable<int> seasons = await CFBPollAPIHelper.GetAvailableSeasons();
            IEnumerable<int> weeks = new List<int>();
            if (seasons == null)
                seasons = new List<int>();
            else
                weeks = await CFBPollAPIHelper.GetAvailableWeeksForSeason(seasons.OrderBy(w => w).LastOrDefault());

            return View(new CFBPollViewModel()
            {
                Selections = new SelectionsViewModel(seasons, weeks)
            });
        }

        [HttpGet]
        public async Task<IActionResult> FillWeeks(int season)
        {
            var seasons = await CFBPollAPIHelper.GetAvailableSeasons();
            var weeks = await CFBPollAPIHelper.GetAvailableWeeksForSeason(season);
            
            return PartialView("_SelectionsPartial", new SelectionsViewModel(seasons, weeks, selectedSeason: season));
        }

        [HttpGet]
        public async Task<IActionResult> FillRankingsGrid(int season, int week)
        {
            var rankingDetails = await CFBPollAPIHelper.GetRankings(season, week);
            var dynamicColumns = ConfigureGridColumns();

            return PartialView("_RankingsPartial", new RankingsViewModel(rankingDetails, dynamicColumns, DefaultSortCriteria));
        }

        #endregion

        #region Private Methods

        private IEnumerable<DynamicColumn> ConfigureGridColumns()
        {
            var dynamicColumnsList = new List<DynamicColumn>()
            {
                new DynamicColumn() { PropertyName = "Rank", Position = 1, Title = "Rank", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                new DynamicColumn() { PropertyName = "TeamName", Position = 2, Title = "Team Name", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                new DynamicColumn() { PropertyName = "Rating", Position = 3, Title = "Rating", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
                new DynamicColumn() { PropertyName = "Record", Position = 4, Title = "Record", Filterable = false, Sortable = true, Format = "", IsCheckboxColumn = false },
            };

            return dynamicColumnsList;
        }

        #endregion
    }
}