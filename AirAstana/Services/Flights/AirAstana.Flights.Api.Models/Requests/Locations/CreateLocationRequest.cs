using AirAstana.Flights.Api.Models.Locations;

namespace AirAstana.Flights.Api.Models.Requests.Locations
{
    /// <summary>
    ///     Запрос на добавление локации.
    /// </summary>
    public sealed class CreateLocationRequest
    {
        /// <summary>
        ///     Данные о локации.
        /// </summary>
        public LocationModel Location { get; set; }
    }
}
