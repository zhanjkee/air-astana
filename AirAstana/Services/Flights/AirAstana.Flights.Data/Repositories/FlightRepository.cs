using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Specifications;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.Repositories
{
    public class FlightRepository : EfRepository<FlightEntity>, IFlightRepository
    {
        [NotNull] private readonly FlightsContext _context;

        public FlightRepository([NotNull] FlightsContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gets the flight by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<FlightEntity> GetFlightByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return (await GetAsync(new FlightSpecification(id), cancellationToken)).SingleOrDefault();
        }

        /// <summary>
        ///     Gets the flight schedules.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.FlightSchedules.OrderBy(x => x.Departure).ToListAsync(cancellationToken);
        }

        /// <summary>
        ///     Gets the flight schedules.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="asc">if set to <c>true</c> [asc].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(DateTime fromDate, DateTime toDate,
            bool asc = true,
            CancellationToken cancellationToken = default)
        {
            var query = _context.FlightSchedules.Where(x => x.Departure >= fromDate && x.Departure <= toDate)
                .AsQueryable();

            query = (asc
                ? query.OrderBy(x => x.Departure)
                : query.OrderByDescending(x => x.Departure)).AsQueryable();

            return await query.Include(fs => fs.Flight).ToListAsync(cancellationToken);
        }

        /// <summary>
        ///     Gets the flight schedule by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<FlightScheduleEntity> GetFlightScheduleByIdAsync(int id)
        {
            return await _context.FlightSchedules.FindAsync(id);
        }

        /// <summary>
        ///     Adds the flight schedule.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <param name="flightSchedule">The flight schedule.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task AddScheduleAsync(FlightEntity flight, FlightScheduleEntity flightSchedule,
            CancellationToken cancellationToken = default)
        {
            (await GetAsync(new FlightSpecification(flight.Id), cancellationToken)).SingleOrDefault()?.Schedules.Add(flightSchedule);
        }

        /// <summary>
        ///     Updates the flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        public async Task UpdateScheduleAsync(FlightScheduleEntity flightSchedule)
        {
            var originalEntity = await GetFlightScheduleByIdAsync(flightSchedule.Id);
            _context.Entry(originalEntity).CurrentValues.SetValues(flightSchedule);
        }

        /// <summary>
        ///     Delete the flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        public void DeleteSchedule(FlightScheduleEntity flightSchedule)
        {
            _context.FlightSchedules.Remove(flightSchedule);
        }

        /// <summary>
        ///     Adds the delay time for flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        /// <param name="delay">The delay.</param>
        public async Task AddDelayTimeAsync(FlightScheduleEntity flightSchedule, TimeSpan delay)
        {
            (await GetFlightScheduleByIdAsync(flightSchedule.Id)).AddDelayTime(delay);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
