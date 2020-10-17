using AirAstana.Auth.Data.Abstract;
using AirAstana.Auth.Data.Context;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace AirAstana.Auth.Data.SqlServer
{
    public sealed class SqlServerDbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;
        public SqlServerDbContextFactory([NotNull]string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public ApplicationDbContext Create()
        {
            if (string.IsNullOrEmpty(_connectionString)) throw new Exception($"Connection string is null or empty.");

            var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>()
                .UseSqlServer(_connectionString);

            var context = new SqlServerDbContext(optionsBuilder.Options);
            context.Database.Migrate();
            return context;
        }
    }
}
