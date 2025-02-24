using CFBPoll.UI.Controllers.Base;
using CFBPoll.UI.ViewModels.Poll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CFBPoll.UI.Controllers
{
    public class PollController : BaseController
    {
        public PollController(IMediator mediator) : base(mediator) { }

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
    }
}