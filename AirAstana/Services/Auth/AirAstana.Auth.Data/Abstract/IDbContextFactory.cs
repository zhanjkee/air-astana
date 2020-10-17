using AirAstana.Auth.Data.Context;

namespace AirAstana.Auth.Data.Abstract
{
    /// <summary>
    ///     Фабрика для создания контекста.
    /// </summary>
    public interface IDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
