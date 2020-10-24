namespace AirAstana.Flights.Options
{
    public class FlightsOptions
    {
        /// <summary>
        ///     The section name.
        /// </summary>
        public const string SectionName = "Flights";

        /// <summary>
        ///     Gets or sets the web address.
        /// </summary>
        public string WebAddress { get; set; }
        /// <summary>
        ///     Gets or sets the connection string.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
