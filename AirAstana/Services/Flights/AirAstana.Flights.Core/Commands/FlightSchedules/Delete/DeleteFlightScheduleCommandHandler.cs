using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Delete
{
    public sealed class DeleteFlightScheduleCommandHandler : IRequestHandler<DeleteFlightScheduleCommand, DeleteFlightScheduleResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFlightScheduleCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<DeleteFlightScheduleResponse> Handle(DeleteFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightScheduleRepository = _unitOfWork.FlightScheduleRepository;
            var flightSchedule = await flightScheduleRepository.GetByIdAsync(request.FlightScheduleId);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightScheduleId}");

            flightScheduleRepository.Delete(flightSchedule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static DeleteFlightScheduleResponse Result(bool success, string message = null)
        {
            return new DeleteFlightScheduleResponse(success, message);
        }
    }
}
