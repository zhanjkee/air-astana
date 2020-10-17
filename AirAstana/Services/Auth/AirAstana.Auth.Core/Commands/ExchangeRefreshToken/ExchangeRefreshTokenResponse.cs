using AirAstana.Auth.Core.Models;

namespace AirAstana.Auth.Core.Commands.ExchangeRefreshToken
{
    public class ExchangeRefreshTokenResponse : ResponseMessage
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}