using AirAstana.Flights.Data.Context;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.SqlServer
{
    public class SqlServerDbContext : FlightsContext
    {
        public SqlServerDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
