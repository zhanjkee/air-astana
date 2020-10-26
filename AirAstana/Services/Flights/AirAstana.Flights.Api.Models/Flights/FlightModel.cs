using System.Collections.Generic;
using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Api.Models.Locations;

namespace AirAstana.Flights.Api.Models.Flights
{
    /// <summary>
    ///     The flight.
    /// </summary>
    public class FlightModel
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
        public LocationModel Source { get; set; }

        /// <summary>
        ///     Gets or sets the destination identifier.
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        public LocationModel Destination { get; set; }

        /// <summary>
        ///     Gets or sets the schedules.
        /// </summary>
        public ICollection<FlightScheduleModel> Schedules { get; set; }
    }
}
