using System;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Domain.Entities
{
    /// <summary>
    ///     The flight schedule entity.
    /// </summary>
    public sealed class FlightScheduleEntity : EntityBase
    {
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
        public FlightEntity Flight { get; set; }

        /// <summary>
        ///     Adds the delay time.
        /// </summary>
        /// <param name="delay">The delay.</param>
        public void AddDelayTime(TimeSpan delay) => Delay = delay;
    }
}