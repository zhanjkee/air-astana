using System;

namespace AirAstana.Flights.Api.Models.Requests.FlightSchedules
{
    /// <summary>
    ///     Запрос для добавления времени заддержки.
    /// </summary>
    public sealed class AddDelayFlightScheduleRequest
    {
        /// <summary>
        ///     ID расписания.
        /// </summary>
        public int FlightScheduleId { get; set; }

        /// <summary>
        ///     Время заддержки в тиках.
        /// </summary>
        public TimeSpan Delay { get; set; }
    }
}
