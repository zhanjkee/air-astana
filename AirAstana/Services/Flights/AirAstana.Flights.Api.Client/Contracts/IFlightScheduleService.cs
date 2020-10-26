using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Api.Models.Requests.FlightSchedules;

namespace AirAstana.Flights.Api.Client.Contracts
{
    public interface IFlightScheduleService
    {
        /// <summary>
        ///     Получить список рейсов.
        /// </summary>
        Task<WebResponse<IEnumerable<FlightScheduleModel>>> GetAsync(GetFlightSchedulesRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Получить рейс по ID.
        /// </summary>
        Task<WebResponse<FlightScheduleModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Создать новый рейс.
        /// </summary>
        Task<WebResponse> CreateAsync(CreateFlightScheduleRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Добавить время задержки.
        /// </summary>
        Task<WebResponse> AddDelayTimeAsync(AddDelayFlightScheduleRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Изменить рейс.
        /// </summary>
        Task<WebResponse> UpdateAsync(UpdateFlightScheduleRequest request, string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Удалить рейс по ID.
        /// </summary>
        Task<WebResponse> DeleteAsync(int id, string accessToken, CancellationToken cancellationToken = default);
    }
}