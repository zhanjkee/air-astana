using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Domain.Entities;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Core.Interfaces.Repositories
{
    public interface IFlightRepository : IRepository<FlightEntity>, IDisposable
    {
        /// <summary>
        ///     Gets the flight schedules.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the flight schedules.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asc">if set to <c>true</c> [asc].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(DateTime fromDate, DateTime toDate,
            bool asc = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets the flight schedule by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task<FlightScheduleEntity> GetFlightScheduleByIdAsync(int id);

        /// <summary>
        ///     Adds the flight schedule.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <param name="flightSchedule">The flight schedule.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AddScheduleAsync(FlightEntity flight, FlightScheduleEntity flightSchedule,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates the flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        Task UpdateScheduleAsync(FlightScheduleEntity flightSchedule);

        /// <summary>
        ///     Adds the delay time for flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        /// <param name="delay">The delay.</param>
        Task AddDelayTimeAsync(FlightScheduleEntity flightSchedule, TimeSpan delay);

        /// <summary>
        ///     Delete the flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        void DeleteSchedule(FlightScheduleEntity flightSchedule);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}