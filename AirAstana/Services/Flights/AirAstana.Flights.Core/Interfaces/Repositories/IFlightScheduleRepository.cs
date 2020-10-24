using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Domain.Entities;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Core.Interfaces.Repositories
{
    public interface IFlightScheduleRepository : IRepository<FlightScheduleEntity>, IDisposable
    {
        /// <summary>
        ///     Gets the flight schedule by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<FlightScheduleEntity> GetFlightScheduleByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}