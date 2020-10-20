using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirAstana.Flights.Data.SqlServer
{
    public sealed class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            // TODO: Добавить возможность чтения connectionString из appsettings.json файла.
            var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>()
                .UseSqlServer("Data Source=(local);Database=airastana_identity;Integrated Security=True");

            return new SqlServerDbContext(optionsBuilder.Options);
        }
    }
}