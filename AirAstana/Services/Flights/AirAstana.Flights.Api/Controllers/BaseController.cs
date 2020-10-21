using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Flights.Api.Controllers
{
    /// <summary>
    ///     Базовый контроллер.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        ///     Gets the mediator.
        /// </summary>
        protected IMediator Mediator => _mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
    }
}
