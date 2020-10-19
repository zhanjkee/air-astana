using AirAstana.Auth.Api.Extensions;
using AirAstana.Auth.Api.Mappers;
using AirAstana.Auth.Api.Models.Common;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [
            HttpPost,
            SwaggerResponse(200, type: typeof(WebResponse<RegisterUserResponse>)),
            SwaggerResponse(400, type: typeof(WebResponse)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
        {
            var registerUserResponse = await Mediator.Send(request.ToCore());

            return registerUserResponse.IsFailure()
                ? this.BadRequestWebResponse(string.Join(". ", registerUserResponse.Errors))
                : this.OkWebResponse(registerUserResponse.ToApi());
        }
    }
}
