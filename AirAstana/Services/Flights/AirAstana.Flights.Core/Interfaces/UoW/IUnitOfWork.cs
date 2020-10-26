using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;

namespace AirAstana.Flights.Core.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Получить репозитории рейсов.
        /// </summary>
        IFlightRepository FlightRepository { get; }

        /// <summary>
        ///     Получить репозитории расписании.
        /// </summary>
        IFlightScheduleRepository FlightScheduleRepository { get; }

        /// <summary>
        ///     Получить репозитории локации.
        /// </summary>
        ILocationRepository LocationRepository { get; }

        /// <summary>
        ///     Сохранить изменения.
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}