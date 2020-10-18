namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The exchange refresh token request model.
    /// </summary>
    public class ExchangeRefreshTokenRequest
    {
        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        ///     Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }
    }
}
