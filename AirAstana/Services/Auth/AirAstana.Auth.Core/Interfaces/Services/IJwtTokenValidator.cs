using AirAstana.Auth.Identity;
using System.Security.Claims;

namespace AirAstana.Auth.Core.Interfaces.Services
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);

        UserIdentity GetUserIdentityFromToken(string token, string signingKey);
    }
}
