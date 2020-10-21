using AirAstana.Flights.Api.Models.Flights;

namespace AirAstana.Flights.Api.Models.Requests.Flights
{
    /// <summary>
    ///     Запрос на изменения данных рейса.
    /// </summary>
    public sealed class UpdateFlightRequest
    {
        /// <summary>
        ///     Данные о рейсе.
        /// </summary>
        public FlightModel Flight { get; set; }
    }
}
