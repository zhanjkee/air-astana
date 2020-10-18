using AirAstana.Auth.Api.Extensions;
using AirAstana.Auth.Api.Mappers;
using AirAstana.Auth.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirAstana.Auth.Api.Controllers
{
    /// <summary>
    ///     Контроллер аккаунтов.
    /// </summary>
    [ApiController]
    [Route("api/account")]
    public class AccountsController : BaseController
    {
        /// <summary>
        ///     The register user action.
        /// </summary>
        /// <param name="request">The request.</param>
        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
        {
            var registerUserResponse = await Mediator.Send(request.ToCore());

            return registerUserResponse.IsFailure()
                ? this.BadRequestWebResponse(string.Join(". ", registerUserResponse.Errors))
                : this.OkWebResponse(registerUserResponse.ToApi());
        }
    }
}
