using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Auth.Api.Controllers
{
    /// <summary>
    ///     Базовый контроллер.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
    }
}
