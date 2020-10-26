using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Locations;
using AirAstana.Flights.Api.Models.Requests.Locations;

namespace AirAstana.Flights.Api.Client.Contracts
{
    public interface ILocationService
    {
        /// <summary>
        ///     Получить список локации.
        /// </summary>
        Task<WebResponse<IEnumerable<LocationModel>>> GetLocationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить локацию по ID.
        /// </summary>
        Task<WebResponse<LocationModel>> GetLocationByIdAsync(int locationId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Создать новую локацию.
        /// </summary>
        Task<WebResponse> CreateAsync(CreateLocationRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Изменить локацию.
        /// </summary>
        Task<WebResponse> UpdateAsync(UpdateLocationRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Удалить локацию по ID.
        /// </summary>
        Task<WebResponse> DeleteAsync(int locationId, string accessToken, CancellationToken cancellationToken = default);
    }
}
