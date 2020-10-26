using System;
using AirAstana.Flights.Api.Models.Flights;

namespace AirAstana.Flights.Api.Models.FlightSchedules
{
    /// <summary>
    ///     The flight schedule.
    /// </summary>
    public class FlightScheduleModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the departure.
        /// </summary>
        public DateTime Departure { get; set; }

        /// <summary>
        ///     Gets or sets the actual departure.
        /// </summary>
        public DateTime? ActualDeparture { get; set; }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///     Gets or sets the delay.
        /// </summary>
        public TimeSpan? Delay { get; set; }

        /// <summary>
        ///     Gets or sets the arrival.
        /// </summary>
        public DateTime Arrival { get; set; }

        /// <summary>
        ///     Gets or sets the flight identifier.
        /// </summary>
        public int FlightId { get; set; }

        /// <summary>
        ///     Gets or sets the flight.
        /// </summary>
        public FlightModel Flight { get; set; }
    }
}
