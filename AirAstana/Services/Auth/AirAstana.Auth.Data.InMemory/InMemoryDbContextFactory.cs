using AirAstana.Auth.Data.Abstract;
using AirAstana.Auth.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Auth.Data.InMemory
{
    public sealed class InMemoryDbContextFactory : IDbContextFactory
    {
        public ApplicationDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(nameof(InMemoryDbContext));

            var context = new InMemoryDbContext(optionsBuilder.Options);
            //context.Database.EnsureCreated();
            return context;
        }
    }
}
