using CFBPoll.UI.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CFBPoll.UI.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly CFBPollAPIHelper CFBPollAPIHelper;
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            CFBPollAPIHelper = new CFBPollAPIHelper(mediator);
            Mediator = mediator;
        }
    }
}
