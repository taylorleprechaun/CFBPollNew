using Microsoft.AspNetCore.Mvc;

namespace CFBPollUI.ViewModels.Shared
{
    public class ErrorViewModel
    {
        public string? Action { get; set; }
        public string? Controller { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorViewModel(string errorMessage, ControllerContext context)
        {
            ErrorMessage = errorMessage;
            Action = context.RouteData.Values["action"]?.ToString();
            Controller = context.RouteData.Values["controller"]?.ToString();
        }
    }
}