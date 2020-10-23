using Newtonsoft.Json;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace AirAstana.Auth.Api.Models.Responses
{
    /// <summary>
    ///     The auth token response model.
    /// </summary>
    public sealed class AuthTokenResponse
    {
        /// <summary>
        ///     Gets the access token.
        /// </summary>
        [JsonProperty(Parameters.AccessToken)]
        public string AccessToken { get; }

        /// <summary>
        ///     Gets the refresh token.
        /// </summary>
        [JsonProperty(Parameters.RefreshToken)]
        public string RefreshToken { get; }

        /// <summary>
        ///     Gets the token identifier.
        /// </summary>
        [JsonProperty(Parameters.IdToken)]
        public string IdToken { get; }

        /// <summary>
        ///     Gets the expires in.
        /// </summary>
        [JsonProperty(Parameters.ExpiresIn)]
        public int ExpiresIn { get;  }

        /// <summary>
        ///     Gets the type of the token.
        /// </summary>
        [JsonProperty(Parameters.TokenType)]
        public string TokenType { get;  }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="idToken">The token identifier.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <param name="tokenType">Type of the token.</param>
        public AuthTokenResponse(string accessToken, string refreshToken, string idToken, int expiresIn, string tokenType)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            IdToken = idToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
        }
    }
}
