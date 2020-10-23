using System;
using AirAstana.Auth.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Models.Responses;
using AirAstana.Auth.Data;
using AirAstana.Auth.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

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

        private static UserEntity GetUserEntity(RegisterUserRequest request)
        {
            return new UserEntity(request.FirstName, request.LastName, request.UserName, request.Email);
        }
    }
}
