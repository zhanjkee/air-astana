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
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        public ExchangeRefreshTokenCommandHandler(IJwtTokenValidator jwtTokenValidator, UserManager<UserEntity> userManager, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _jwtTokenValidator = jwtTokenValidator ?? throw new ArgumentNullException(nameof(jwtTokenValidator));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtFactory = jwtFactory ?? throw new ArgumentNullException(nameof(jwtFactory));
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));
        }

        public async Task<ExchangeRefreshTokenResponse> Handle(ExchangeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = _jwtTokenValidator.GetUserIdentityFromToken(request.AccessToken, request.SigningKey);
            if (userIdentity == null) return InvalidToken();

            var user = await _userManager.FindByIdAsync(userIdentity.Id);
            if (user == null) return InvalidToken();

            if (!user.HasValidRefreshToken(request.RefreshToken)) return InvalidToken();

            var jwtToken = _jwtFactory.GenerateEncodedToken(user.ToModel(), request.ClientId);
            var refreshToken = _tokenFactory.GenerateToken();
            // Delete the token we've exchanged.
            user.RemoveRefreshToken(request.RefreshToken);
            // Add the new one.
            user.AddRefreshToken(refreshToken, user.Id, request.RemoteIpAddress);
            await _userManager.UpdateAsync(user);
            return new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true);
        }

        private ExchangeRefreshTokenResponse InvalidToken()
        {
            return new ExchangeRefreshTokenResponse(false, "invalid_token.");
        }
    }
}
