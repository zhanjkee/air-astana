using System;
using AirAstana.Flights.Data.Abstract;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Data.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Flights.Data.SqlServer
{
    public sealed class SqlServerDbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;
        public SqlServerDbContextFactory([NotNull]string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public FlightsContext Create()
        {
            if (string.IsNullOrEmpty(_connectionString)) throw new Exception($"Connection string is null or empty.");

            var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>()
                .UseSqlServer(_connectionString);

            var context = new SqlServerDbContext(optionsBuilder.Options);
            context.Database.Migrate();
            SeedDataExtension.SeedData(context);
            return context;
        }
    }
}
