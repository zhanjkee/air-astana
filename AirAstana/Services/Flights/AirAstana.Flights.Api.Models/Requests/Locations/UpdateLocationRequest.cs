using AirAstana.Flights.Api.Models.Locations;

namespace AirAstana.Flights.Api.Models.Requests.Locations
{
    /// <summary>
    ///     Запрос на изменение локации.
    /// </summary>
    public sealed class UpdateLocationRequest
    {
        /// <summary>
        ///     Данные о локации.
        /// </summary>
        public LocationModel Location { get; set; }
    }
}
