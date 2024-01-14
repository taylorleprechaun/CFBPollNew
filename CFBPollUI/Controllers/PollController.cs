using CFBPoll.Data.Modules;
using CFBPollDTOs;
using CFBPollUI.ViewModels.Poll;
using Microsoft.AspNetCore.Mvc;

namespace CFBPollUI.Controllers
{
    public class PollController : BaseController
    {
        private readonly FileSystemDataModule _fileSystemDataModule;

        public PollController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) 
        {
            _fileSystemDataModule = new FileSystemDataModule(_config);
        }

        public IActionResult Index()
        {
            var cfbPollVM = new CFBPollViewModel(_fileSystemDataModule.GetSeasons(), new List<int>());

            return View(cfbPollVM);
        }

        [HttpGet]
        public IActionResult FillWeeks(int season)
        {
            var selectionsVM = new SelectionsViewModel(_fileSystemDataModule.GetSeasons(), _fileSystemDataModule.GetWeeks(season), selectedSeason: season);

            return PartialView("_Selections", selectionsVM);
        }
    }
}