namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The login request model.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///     Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        ///     Gets or sets the locale.
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        ///     Gets or sets the zone information.
        /// </summary>
        public string ZoneInfo { get; set; }
    }
}
