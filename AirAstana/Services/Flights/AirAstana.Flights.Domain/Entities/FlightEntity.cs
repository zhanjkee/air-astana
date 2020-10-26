using System.Collections.Generic;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Domain.Entities
{
    /// <summary>
    ///     The flight entity.
    /// </summary>
    public class FlightEntity : EntityBase
    {
        /// <summary>
        ///     Gets or sets the flight number.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        ///     Gets or sets the source identifier.
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        public virtual LocationEntity Source { get; set; }

        /// <summary>
        ///     Gets or sets the destination identifier.
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        public virtual LocationEntity Destination { get; set; }

        /// <summary>
        ///     Gets or sets the schedules.
        /// </summary>
        public virtual ICollection<FlightScheduleEntity> Schedules { get; set; }
    }
}
