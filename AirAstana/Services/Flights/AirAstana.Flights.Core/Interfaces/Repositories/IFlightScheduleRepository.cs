using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Domain.Entities;
using AirAstana.Shared.SeedWork;

namespace AirAstana.Flights.Core.Interfaces.Repositories
{
    public interface IFlightScheduleRepository : IRepository<FlightScheduleEntity>
    {
        /// <summary>
        ///     Получить список расписании по заданным параметрам.
        /// </summary>
        Task<IEnumerable<FlightScheduleEntity>> GetFlightSchedulesAsync(DateTime fromDate, DateTime toDate, bool asc = true, CancellationToken cancellationToken = default);
    }
}