using Newtonsoft.Json;
using OpenIddict.Abstractions;
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
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets the refresh token.
        /// </summary>
        [JsonProperty(Parameters.RefreshToken)]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Gets the token identifier.
        /// </summary>
        [JsonProperty(Parameters.IdToken)]
        public string IdToken { get; set; }

        /// <summary>
        ///     Gets the expires in.
        /// </summary>
        [JsonProperty(Parameters.ExpiresIn)]
        public long? ExpiresIn { get; set; }

        /// <summary>
        ///     Gets the type of the token.
        /// </summary>
        [JsonProperty(Parameters.TokenType)]
        public string TokenType { get; set; }

        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        [JsonProperty(Parameters.Error)]
        public string Error { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="idToken">The token identifier.</param>
        /// <param name="expiresIn">The expires in.</param>
        /// <param name="tokenType">Type of the token.</param>
        /// <param name="error">The error.</param>
        public AuthTokenResponse(string accessToken, string refreshToken, string idToken, int expiresIn, string tokenType, string error)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            IdToken = idToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
            Error = error;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthTokenResponse"/> class.
        /// </summary>
        /// <param name="openIddictResponse">The open iddict response.</param>
        public AuthTokenResponse(OpenIddictResponse openIddictResponse)
        {
            AccessToken = openIddictResponse.AccessToken;
            RefreshToken = openIddictResponse.RefreshToken;
            Error = openIddictResponse.Error;
            ExpiresIn = openIddictResponse.ExpiresIn;
            IdToken = openIddictResponse.IdToken;
            TokenType = openIddictResponse.TokenType;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthTokenResponse"/> class.
        /// </summary>
        public AuthTokenResponse()
        {
            
        }
    }
}
