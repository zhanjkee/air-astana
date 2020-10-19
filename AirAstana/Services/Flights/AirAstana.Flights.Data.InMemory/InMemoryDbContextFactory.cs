using AirAstana.Flights.Data.Abstract;
using AirAstana.Flights.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.InMemory
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        public FlightsContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InMemoryDbContext>().UseInMemoryDatabase(nameof(InMemoryDbContext));
            var context = new InMemoryDbContext(optionsBuilder.Options);
            return context;
        }
    }
}
