using AirAstana.Flights.Data.Context;

namespace AirAstana.Flights.Data.Abstract
{
    /// <summary>
    ///     Фабрика для создания контекста.
    /// </summary>
    public interface IDbContextFactory
    {
        FlightsContext Create();
    }
}
