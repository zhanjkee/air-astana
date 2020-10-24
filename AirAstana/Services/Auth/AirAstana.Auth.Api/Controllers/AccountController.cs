using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AirAstana.Auth.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Models.Responses;
using AirAstana.Auth.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace AirAstana.Auth.Api.Controllers
{
    /// <summary>
    ///     Контроллер аккаунтов.
    /// </summary>
    [ApiController]
    [Route("api/account")]
    public class AccountController : BaseController
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<UserEntity> userManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        ///     Получить информацию о пользователе.
        /// </summary>
        [Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet("~/connect/userinfo"), Produces("application/json")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(
                    authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                    properties: new AuthenticationProperties(new Dictionary<string, string>
                    {
                        [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidToken,
                        [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                            "The specified access token is bound to an account that no longer exists."
                    }));
            }

            var userInfo = GetUserInfo(User);

            return Ok(userInfo);
        }

        /// <summary>
        ///     Регистрация нового пользователя.
        /// </summary>
        // POST api/account
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }
                user = GetUserEntity(request);

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return Ok(new RegisterUserResponse(user.Id));
                }

                _logger.LogWarning(result.ToString());
                AddErrors(result);
            }
            return BadRequest(ModelState);
        }

        private static UserInfoResponse GetUserInfo(ClaimsPrincipal principal)
        {
            return new UserInfoResponse(
                userName: principal.Identity.Name,
                isAuthenticated: principal.Identity.IsAuthenticated,
                claims: principal.Claims.Where(x=>x.Type != OpenIddictConstants.Claims.Private.Scope));
        }

        private static UserEntity GetUserEntity(RegisterUserRequest request)
        {
            return new UserEntity(request.FirstName, request.LastName, request.UserName, request.Email);
        }
    }
}
