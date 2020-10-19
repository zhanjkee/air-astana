using AirAstana.Flights.Data.Context;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.InMemory
{
    internal class InMemoryDbContext : FlightsContext
    {
        public InMemoryDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}