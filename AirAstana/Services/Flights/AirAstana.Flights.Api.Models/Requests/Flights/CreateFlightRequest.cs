using AirAstana.Flights.Api.Models.Flights;

namespace AirAstana.Flights.Api.Models.Requests.Flights
{
    /// <summary>
    ///     Запрос на добавление рейса.
    /// </summary>
    public sealed class CreateFlightRequest
    {
        /// <summary>
        ///     Данные о рейсе.
        /// </summary>
        public FlightModel Flight { get; set; }
    }
}
