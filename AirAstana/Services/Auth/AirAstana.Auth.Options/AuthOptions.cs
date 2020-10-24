namespace AirAstana.Auth.Options
{
    public class AuthOptions
    {
        /// <summary>
        ///     The section name.
        /// </summary>
        public const string SectionName = "Auth";

        /// <summary>
        ///     Gets or sets the web address.
        /// </summary>
        public string WebAddress { get; set; }

        /// <summary>
        ///     Gets or sets the issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        ///     Gets or sets the signing key.
        /// </summary>
        public string SecretKey { get; set; }
    }
}
