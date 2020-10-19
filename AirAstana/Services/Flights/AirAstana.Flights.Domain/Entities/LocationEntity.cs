using System;
using System.Collections.Generic;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Domain.Entities
{
    /// <summary>
    ///     The location entity.
    /// </summary>
    public sealed class LocationEntity : EntityBase
    {
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
