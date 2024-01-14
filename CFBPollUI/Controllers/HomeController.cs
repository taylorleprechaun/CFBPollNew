using Microsoft.AspNetCore.Mvc;

namespace CFBPollUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
