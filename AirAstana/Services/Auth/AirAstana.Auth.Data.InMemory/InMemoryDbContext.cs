using AirAstana.Auth.Data.Context;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AirAstana.Auth.Data.InMemory
{
    /// <summary>
    ///     Создан для unit-тестов.
    /// </summary>
    public class InMemoryDbContext : ApplicationDbContext
    {
        public InMemoryDbContext([NotNull]DbContextOptions options) : base(options)
        {
        }
    }
}
