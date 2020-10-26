using System;

namespace AirAstana.Flights.Api.Models.Requests.FlightSchedules
{
    /// <summary>
    ///     Запрос на получение списка расписании.
    /// </summary>
    public sealed class GetFlightSchedulesRequest
    {
        /// <summary>
        ///     Начало периода.
        /// </summary>
        public DateTime? FromDate { get; set; }
        /// <summary>
        ///     Конец периода.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        ///     Сортировка по дате вылета.
        /// </summary>
        public bool Asc { get; set; } = true;
    }
}
