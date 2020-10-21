using AirAstana.Flights.Api.Models.FlightSchedules;

namespace AirAstana.Flights.Api.Models.Requests.FlightSchedules
{
    /// <summary>
    ///     Запрос на изменение расписания рейса.
    /// </summary>
    public sealed class UpdateFlightScheduleRequest
    {
        /// <summary>
        ///     Данные о расписания рейса.
        /// </summary>
        public FlightScheduleModel FlightSchedule { get; set; }
    }
}
