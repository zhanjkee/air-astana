using System.Collections.Generic;
using AirAstana.Flights.Core.Models.FlightSchedules;
using AirAstana.Flights.Core.Models.Locations;

namespace AirAstana.Flights.Core.Models.Flights
{
    public class Flight
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

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
        public Location Source { get; set; }

        /// <summary>
        ///     Gets or sets the destination identifier.
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        public Location Destination { get; set; }

        /// <summary>
        ///     Gets or sets the schedules.
        /// </summary>
        public ICollection<FlightSchedule> Schedules { get; set; }
    }
}
