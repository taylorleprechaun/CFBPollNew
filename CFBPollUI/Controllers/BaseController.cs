using CFBPollUI.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CFBPollUI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile($"appsettings.json");
            configurationBuilder.AddJsonFile($"appsettings-private.json");
            _config = configurationBuilder.Build();
        }

        protected IActionResult HandleError(Exception ex)
        {
            var errorViewModel = new ErrorViewModel(ex.Message, this.ControllerContext);
            return PartialView("_Error", errorViewModel);
        }
    }
}
