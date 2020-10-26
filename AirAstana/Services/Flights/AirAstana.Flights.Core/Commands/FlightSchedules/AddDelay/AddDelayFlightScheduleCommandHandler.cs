using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.AddDelay
{
    public sealed class AddDelayFlightScheduleCommandHandler : IRequestHandler<AddDelayFlightScheduleCommand, AddDelayFlightScheduleResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDelayFlightScheduleCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<AddDelayFlightScheduleResponse> Handle(AddDelayFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightScheduleRepository = _unitOfWork.FlightScheduleRepository;

            var flightSchedule = await flightScheduleRepository.GetByIdAsync(request.FlightScheduleId);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightScheduleId}");

            flightSchedule.Delay = request.Delay;

            flightScheduleRepository.Update(flightSchedule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static AddDelayFlightScheduleResponse Result(bool success, string message = null)
        {
            return new AddDelayFlightScheduleResponse(success, message);
        }
    }
}
