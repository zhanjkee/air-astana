using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.Repositories
{
    public class LocationRepository : EfRepository<LocationEntity>
    {
        public LocationRepository([NotNull] FlightsContext context) : base(context)
        {
        }
    }
}
