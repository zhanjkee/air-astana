using System;

namespace AirAstana.Flights.Api.Models.Locations
{
    /// <summary>
    ///     The location.
    /// </summary>
    public class LocationModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Gets or sets the location time zone.
        /// </summary>
        public TimeZoneInfo LocationTimeZone { get; set; }

        /// <summary>
        ///     Gets or sets the time zone identifier.
        /// </summary>
        public string TimeZoneId
        {
            get => LocationTimeZone.Id;
            set => LocationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(value);
        }
    }
}
