using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Specifications;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.Repositories
{
    public class FlightScheduleRepository : EfRepository<FlightScheduleEntity>, IFlightScheduleRepository
    {
        public FlightScheduleRepository([NotNull] FlightsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(DateTime fromDate, DateTime toDate, bool asc = true,
            CancellationToken cancellationToken = default)
        {
            var schedules = await GetAsync(
                new FlightScheduleSpecification(x => x.Departure >= fromDate && x.Departure <= toDate),
                cancellationToken);

            schedules = asc
                ? schedules.OrderBy(x => x.Departure)
                : schedules.OrderByDescending(x => x.Departure);

            return schedules.ToList();
        }
    }
}
