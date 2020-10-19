using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Specifications;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.Repositories
{
    public class FlightRepository : EfRepository<FlightEntity>, IDisposable
    {
        [NotNull] private readonly FlightsContext _context;

        public FlightRepository([NotNull] FlightsContext context) : base(context)
        {
            _context = context;
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
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task UpdateScheduleAsync(FlightScheduleEntity flightSchedule, CancellationToken cancellationToken = default)
        {
            var originalEntity = await _context.FlightSchedules.FindAsync(flightSchedule.Id);
            _context.Entry(originalEntity).CurrentValues.SetValues(flightSchedule);
        }

        /// <summary>
        ///     Adds the delay time for flight schedule.
        /// </summary>
        /// <param name="flightSchedule">The flight schedule.</param>
        /// <param name="delay">The delay.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task AddDelayTimeAsync(FlightScheduleEntity flightSchedule, TimeSpan delay, CancellationToken cancellationToken = default)
        {
            (await _context.FlightSchedules.FindAsync(flightSchedule.Id, cancellationToken)).AddDelayTime(delay);
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
