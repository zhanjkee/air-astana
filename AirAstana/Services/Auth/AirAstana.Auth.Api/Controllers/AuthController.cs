using AirAstana.Auth.Api.Extensions;
using AirAstana.Auth.Api.Mappers;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Options;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AirAstana.Auth.Api.Controllers
{    
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly AuthOptions _authOptions;
        public AuthController(AuthOptions authOptions)
        {
            _authOptions = authOptions ?? throw new ArgumentNullException(nameof(authOptions));
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
                request.ToCore(_authOptions.SecretKey, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));

            return exchangeRefreshTokenResponse.IsFailure()
                ? this.BadRequestWebResponse(exchangeRefreshTokenResponse.Message)
                : this.OkWebResponse(exchangeRefreshTokenResponse.ToApi());
        }

    }
}
