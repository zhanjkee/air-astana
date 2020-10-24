using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.AddDelay
{
    public sealed class AddDelayFlightScheduleCommandHandler : IRequestHandler<AddDelayFlightScheduleCommand, AddDelayFlightScheduleResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public AddDelayFlightScheduleCommandHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<AddDelayFlightScheduleResponse> Handle(AddDelayFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightSchedule = await _flightRepository.GetFlightScheduleByIdAsync(request.FlightScheduleId);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightScheduleId}");

            flightSchedule.Delay = TimeSpan.FromTicks(request.DelayTicks);

            await _flightRepository.UpdateScheduleAsync(flightSchedule);
            await _flightRepository.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static AddDelayFlightScheduleResponse Result(bool success, string message = null)
        {
            return new AddDelayFlightScheduleResponse(success, message);
        }
    }
}
