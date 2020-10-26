using AirAstana.Flights.Api.Models.FlightSchedules;

namespace AirAstana.Flights.Api.Models.Requests.FlightSchedules
{
    /// <summary>
    ///     Запрос на добавление расписания рейса.
    /// </summary>
    public sealed class CreateFlightScheduleRequest
    {
        /// <summary>
        ///     Данные о расписания рейса.
        /// </summary>
        public FlightScheduleModel FlightSchedule { get; set; }
    }
}
