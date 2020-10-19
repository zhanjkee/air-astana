using System.Collections.Generic;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Domain.Entities
{
    /// <summary>
    ///     The flight entity.
    /// </summary>
    public sealed class FlightEntity : EntityBase
    {
        /// <summary>
        ///     Gets or sets the flight number.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        public LocationEntity Source { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        public LocationEntity Destination { get; set; }

        /// <summary>
        ///     Gets or sets the schedules.
        /// </summary>
        public ICollection<FlightScheduleEntity> Schedules { get; set; }
    }
}
