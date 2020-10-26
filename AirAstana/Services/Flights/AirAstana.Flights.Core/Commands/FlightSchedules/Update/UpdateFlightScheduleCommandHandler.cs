using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Update
{
    public sealed class UpdateFlightScheduleCommandHandler : IRequestHandler<UpdateFlightScheduleCommand, UpdateFlightScheduleResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFlightScheduleCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UpdateFlightScheduleResponse> Handle(UpdateFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightScheduleRepository = _unitOfWork.FlightScheduleRepository;
            var flightSchedule = await flightScheduleRepository.GetByIdAsync(request.FlightSchedule.Id);
            if (flightSchedule == null) return Result(false, $"The flight schedule does not exists by id: {request.FlightSchedule.Id}");
            
            flightScheduleRepository.Update(request.FlightSchedule.ToEntity());
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static UpdateFlightScheduleResponse Result(bool success, string message = null)
        {
            return new UpdateFlightScheduleResponse(success, message);
        }
    }
}
