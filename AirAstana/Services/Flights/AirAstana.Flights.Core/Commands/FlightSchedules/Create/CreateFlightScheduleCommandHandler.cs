using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Create
{
    public sealed class CreateFlightScheduleCommandHandler : IRequestHandler<CreateFlightScheduleCommand, CreateFlightScheduleResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public CreateFlightScheduleCommandHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<CreateFlightScheduleResponse> Handle(CreateFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.FlightId);
            if (flight == null) return Result(false, $"The flight does not exists by id: {request.FlightId}");
            
            await _flightRepository.AddScheduleAsync(flight, request.FlightSchedule.ToEntity(), cancellationToken);
            await _flightRepository.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static CreateFlightScheduleResponse Result(bool success, string message = null)
        {
            return new CreateFlightScheduleResponse(success, message);
        }
    }
}
