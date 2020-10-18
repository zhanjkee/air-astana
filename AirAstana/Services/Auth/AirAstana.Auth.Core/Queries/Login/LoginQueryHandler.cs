using AirAstana.Auth.Core.Interfaces.Repositories;
using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Core.Mappers;
using AirAstana.Auth.Core.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Queries.Login
{
    public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;        

        public LoginQueryHandler(IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtFactory = jwtFactory ?? throw new ArgumentNullException(nameof(jwtFactory));
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));            
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // Ensure we have a user with the given userName.
            var user = await _userRepository.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return LoginFailure("User does not exist in the system.");
            }

            // Validate password.
            if (!await _userRepository.CheckPasswordAsync(user, request.Password)) return LoginFailure("Incorrect password.");

            // Generate refresh token.
            var refreshToken = _tokenFactory.GenerateToken();
            user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
            await _userRepository.UpdateUserAsync(user);

            // Generate access token.
            var accessToken = _jwtFactory.GenerateEncodedToken(user.ToModel(await _userRepository.GetRolesAsync(user)), request.ClientId);
            return new LoginResponse(accessToken, refreshToken, true);
        }

        private LoginResponse LoginFailure(string msg)
        {
            return new LoginResponse(new[] { new Error("login_failure", msg) }, message: msg);
        }
    }
}
