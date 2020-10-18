using AirAstana.Auth.Core.Interfaces.Repositories;
using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Core.Mappers;
using AirAstana.Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Commands.ExchangeRefreshToken
{
    public sealed class ExchangeRefreshTokenCommandHandler : IRequestHandler<ExchangeRefreshTokenCommand, ExchangeRefreshTokenResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenValidator _jwtTokenValidator;        
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        public ExchangeRefreshTokenCommandHandler(IUserRepository userRepository, IJwtTokenValidator jwtTokenValidator, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtTokenValidator = jwtTokenValidator ?? throw new ArgumentNullException(nameof(jwtTokenValidator));            
            _jwtFactory = jwtFactory ?? throw new ArgumentNullException(nameof(jwtFactory));
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
        }

        public async Task<ExchangeRefreshTokenResponse> Handle(ExchangeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = _jwtTokenValidator.GetUserIdentityFromToken(request.AccessToken, request.SigningKey);
            if (userIdentity == null) return InvalidToken();

            var user = await _userRepository.FindByIdAsync(userIdentity.Id);
            if (user == null) return InvalidToken();
            
            if (!user.HasValidRefreshToken(request.RefreshToken)) return InvalidToken();

            var jwtToken = _jwtFactory.GenerateEncodedToken(user.ToModel(await _userRepository.GetRolesAsync(user)), request.ClientId);
            var refreshToken = _tokenFactory.GenerateToken();
            // Delete the token we've exchanged.
            user.RemoveRefreshToken(request.RefreshToken);
            // Add the new one.
            user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
            await _userRepository.UpdateUserAsync(user);
            return new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true);
        }

        private ExchangeRefreshTokenResponse InvalidToken()
        {
            return new ExchangeRefreshTokenResponse(false, "invalid_token.");
        }
    }
}
