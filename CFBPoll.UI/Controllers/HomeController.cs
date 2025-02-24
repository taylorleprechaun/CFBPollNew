using CFBPoll.UI.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CFBPoll.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
