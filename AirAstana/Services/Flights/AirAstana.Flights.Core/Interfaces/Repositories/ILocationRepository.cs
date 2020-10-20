using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Domain.Entities;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Core.Interfaces.Repositories
{
    public interface ILocationRepository : IRepository<LocationEntity>, IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}