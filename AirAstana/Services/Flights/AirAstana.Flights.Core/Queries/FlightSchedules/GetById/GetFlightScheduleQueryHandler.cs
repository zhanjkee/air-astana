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
        private readonly IFlightRepository _flightRepository;

        public GetFlightScheduleQueryHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<FlightSchedule> Handle(GetFlightScheduleQuery request, CancellationToken cancellationToken)
        {
            return (await _flightRepository.GetFlightScheduleByIdAsync(request.FlightScheduleId)).ToModel();
        }
    }
}
