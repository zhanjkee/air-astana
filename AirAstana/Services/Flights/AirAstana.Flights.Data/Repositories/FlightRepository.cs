using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Domain.Entities;
using JetBrains.Annotations;

namespace AirAstana.Flights.Data.Repositories
{
    public class FlightRepository : EfRepository<FlightEntity>, IFlightRepository
    {
        public FlightRepository([NotNull] FlightsContext context) : base(context)
        {
        }
    }
}
