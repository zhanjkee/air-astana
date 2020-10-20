using System;
using AirAstana.Flights.Core.Models.Flights;

namespace AirAstana.Flights.Core.Models.FlightSchedules
{
    public class FlightSchedule
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
        ///     Gets or sets the flight identifier.
        /// </summary>
        public int FlightId { get; set; }

        /// <summary>
        ///     Gets or sets the flight.
        /// </summary>
        public Flight Flight { get; set; }
    }
}
