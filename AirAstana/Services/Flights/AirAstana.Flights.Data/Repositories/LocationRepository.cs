using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.Repositories
{
    public class LocationRepository : EfRepository<LocationEntity>, ILocationRepository
    {
        private readonly FlightsContext _context;
        public LocationRepository([NotNull] FlightsContext context) : base(context)
        {
            _context = context;
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
