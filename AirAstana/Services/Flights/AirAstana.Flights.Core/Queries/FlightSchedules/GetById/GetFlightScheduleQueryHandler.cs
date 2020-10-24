using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.FlightSchedules;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetById
{
    public sealed class GetFlightScheduleQueryHandler : IRequestHandler<GetFlightScheduleQuery, FlightSchedule>
    {
        private readonly IFlightScheduleRepository _flightScheduleRepository;

        public GetFlightScheduleQueryHandler([NotNull] IFlightScheduleRepository flightScheduleRepository)
        {
            _flightScheduleRepository = flightScheduleRepository ?? throw new ArgumentNullException(nameof(flightScheduleRepository));
        }

        public async Task<FlightSchedule> Handle(GetFlightScheduleQuery request, CancellationToken cancellationToken)
        {
            return (await _flightScheduleRepository.GetFlightScheduleByIdAsync(request.FlightScheduleId, cancellationToken)).ToModel();
        }
    }
}
