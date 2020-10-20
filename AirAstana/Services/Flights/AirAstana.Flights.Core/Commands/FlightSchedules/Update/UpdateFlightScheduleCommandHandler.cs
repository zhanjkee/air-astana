using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Update
{
    public sealed class UpdateFlightScheduleCommandHandler : IRequestHandler<UpdateFlightScheduleCommand, UpdateFlightScheduleResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public UpdateFlightScheduleCommandHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<UpdateFlightScheduleResponse> Handle(UpdateFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightSchedule = await _flightRepository.GetFlightScheduleByIdAsync(request.FlightSchedule.Id);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightSchedule.Id}");
            
            await _flightRepository.UpdateScheduleAsync(request.FlightSchedule.ToEntity());
            await _flightRepository.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static UpdateFlightScheduleResponse Result(bool success, string message = null)
        {
            return new UpdateFlightScheduleResponse(success, message);
        }
    }
}
