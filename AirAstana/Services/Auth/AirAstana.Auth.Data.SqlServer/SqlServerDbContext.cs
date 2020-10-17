using AirAstana.Auth.Data.Context;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Auth.Data.SqlServer
{
    public class SqlServerDbContext : ApplicationDbContext
    {
        public SqlServerDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
