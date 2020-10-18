namespace AirAstana.Auth.Options
{
    public class ServiceOptions
    {
        /// <summary>
        ///     The section name.
        /// </summary>
        public const string SectionName = "AuthSettings";

        /// <summary>
        ///     Gets or sets the secret key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
