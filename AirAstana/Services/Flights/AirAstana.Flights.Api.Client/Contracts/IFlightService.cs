using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Flights;
using AirAstana.Flights.Api.Models.Requests.Flights;

namespace AirAstana.Flights.Api.Client.Contracts
{
    public interface IFlightService
    {
        /// <summary>
        ///     Получить список рейсов.
        /// </summary>
        Task<WebResponse<IEnumerable<FlightModel>>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить рейс по ID.
        /// </summary>
        Task<WebResponse<FlightModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Создать новый рейс.
        /// </summary>
        Task<WebResponse> CreateAsync(CreateFlightRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Изменить рейс.
        /// </summary>
        Task<WebResponse> UpdateAsync(UpdateFlightRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Удалить рейс по ID.
        /// </summary>
        Task<WebResponse> DeleteAsync(int id, string accessToken, CancellationToken cancellationToken = default);
    }
}