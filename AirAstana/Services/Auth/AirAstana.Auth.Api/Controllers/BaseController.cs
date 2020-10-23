using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Auth.Api.Controllers
{
    /// <summary>
    ///     Базовый контроллер.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        ///     Добавить ошибки в ModelState.
        /// </summary>
        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
