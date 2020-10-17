using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Core.Mappers;
using AirAstana.Auth.Core.Models;
using AirAstana.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Queries.Login
{
    public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly UserManager<UserEntity> _userManager;

        public LoginQueryHandler(IJwtFactory jwtFactory, ITokenFactory tokenFactory, UserManager<UserEntity> userManager)
        {
            _jwtFactory = jwtFactory ?? throw new ArgumentNullException(nameof(jwtFactory));
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // Ensure we have a user with the given userName.
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return LoginFailure("User does not exist in the system.");
            }

            // Validate password.
            if (!await _userManager.CheckPasswordAsync(user, request.Password)) return LoginFailure("Incorrect password.");

            // Generate refresh token.
            var refreshToken = _tokenFactory.GenerateToken();
            user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
            await _userManager.UpdateAsync(user);

            // Generate access token.
            return new LoginResponse(_jwtFactory.GenerateEncodedToken(user.ToModel(), request.ClientId), refreshToken, true);
        }

        private LoginResponse LoginFailure(string msg)
        {
            return new LoginResponse(new[] { new Error("login_failure", msg) });
        }
    }
}
