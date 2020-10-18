using System.Security.Claims;
using System.Text;
using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Identity;
using AirAstana.Auth.Infrastructure.Auth.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AirAstana.Auth.Infrastructure.Auth
{
    public sealed class JwtTokenValidator : IJwtTokenValidator
    {
        private readonly IJwtTokenHandler _jwtTokenHandler;

        public JwtTokenValidator(IJwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey)
        {
            return _jwtTokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                ValidateLifetime = true
            });
        }

        public UserIdentity GetUserIdentityFromToken(string token, string signingKey)
        {
            var principal = GetPrincipalFromToken(token, signingKey);
            if (principal == null) return null;
            return new UserIdentity(principal.Claims);
        }
    }
}
