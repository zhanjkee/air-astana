using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Specifications;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.Repositories
{
    public class FlightScheduleRepository : EfRepository<FlightScheduleEntity>, IFlightScheduleRepository
    {
        private readonly FlightsContext _context;
        public FlightScheduleRepository([NotNull] FlightsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FlightScheduleEntity> GetFlightScheduleByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return (await GetAsync(new FlightScheduleSpecification(id), cancellationToken)).SingleOrDefault();
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
