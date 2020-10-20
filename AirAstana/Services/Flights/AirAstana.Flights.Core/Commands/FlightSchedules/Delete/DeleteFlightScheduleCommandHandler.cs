using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Delete
{
    public sealed class DeleteFlightScheduleCommandHandler : IRequestHandler<DeleteFlightScheduleCommand, DeleteFlightScheduleResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightScheduleCommandHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<DeleteFlightScheduleResponse> Handle(DeleteFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightSchedule = await _flightRepository.GetFlightScheduleByIdAsync(request.FlightScheduleId);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightScheduleId}");

            _flightRepository.DeleteSchedule(flightSchedule);
            await _flightRepository.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static DeleteFlightScheduleResponse Result(bool success, string message = null)
        {
            return new DeleteFlightScheduleResponse(success, message);
        }
    }
}
