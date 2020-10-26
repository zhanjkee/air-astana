using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Data.Abstract;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Repositories;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightsContext _context;

        public UnitOfWork([NotNull] IDbContextFactory dbContextFactory)
        {
            if (dbContextFactory == null) throw new ArgumentNullException(nameof(dbContextFactory));
            _context = dbContextFactory.Create();
            FlightRepository = new FlightRepository(_context);
            FlightScheduleRepository = new FlightScheduleRepository(_context);
            LocationRepository = new LocationRepository(_context);
        }

        public IFlightRepository FlightRepository { get; }
        public IFlightScheduleRepository FlightScheduleRepository { get; }
        public ILocationRepository LocationRepository { get; }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
