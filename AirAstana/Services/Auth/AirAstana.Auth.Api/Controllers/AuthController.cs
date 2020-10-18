using AirAstana.Auth.Api.Extensions;
using AirAstana.Auth.Api.Mappers;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Options;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AirAstana.Auth.Api.Controllers
{
    /// <summary>
    ///     Контроллер аутентификации/авторизации.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly ServiceOptions _serviceOptions;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="serviceOptions">The service options.</param>
        /// <exception cref="ArgumentNullException">serviceOptions</exception>
        public AuthController(ServiceOptions serviceOptions)
        {
            _serviceOptions = serviceOptions ?? throw new ArgumentNullException(nameof(serviceOptions));
        }

        /// <summary>
        ///     Login action.
        /// </summary>
        /// <param name="request">The request.</param>
        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginResponse = await Mediator.Send(request.ToCore(Request.HttpContext.Connection.RemoteIpAddress?.ToString()));

            return loginResponse.IsFailure()
                ? this.BadRequestWebResponse(loginResponse.Message)          
                : this.OkWebResponse(loginResponse.ToApi());
        }

        /// <summary>
        ///     Refresh token action.
        /// </summary>
        /// <param name="request">The request.</param>
        // POST api/auth/refreshToken
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] ExchangeRefreshTokenRequest request)
        {
            var exchangeRefreshTokenResponse = await Mediator.Send(
                request.ToCore(_serviceOptions.SecretKey, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));

            return exchangeRefreshTokenResponse.IsFailure()
                ? this.BadRequestWebResponse(exchangeRefreshTokenResponse.Message)
                : this.OkWebResponse(exchangeRefreshTokenResponse.ToApi());
        }

    }
}
