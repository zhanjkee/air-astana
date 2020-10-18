using AirAstana.Auth.Api.Models.Common;

namespace AirAstana.Auth.Api.Models.Responses
{
    /// <summary>
    ///     The exchange refresh token response model.
    /// </summary>
    public class ExchangeRefreshTokenResponse
    {
        /// <summary>
        ///     Gets the access token.
        /// </summary>
        public AccessToken AccessToken { get; }
        /// <summary>
        ///     Gets the refresh token.
        /// </summary>
        public string RefreshToken { get; }
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
