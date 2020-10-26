using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Create
{
    public sealed class CreateFlightScheduleCommandHandler : IRequestHandler<CreateFlightScheduleCommand, CreateFlightScheduleResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFlightScheduleCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateFlightScheduleResponse> Handle(CreateFlightScheduleCommand request, CancellationToken cancellationToken)
        {
            var flightRepository = _unitOfWork.FlightRepository;
            var flight = await flightRepository.GetByIdAsync(request.FlightSchedule.FlightId);
            if (flight == null) return Result(false, $"The flight does not exists by id: {request.FlightSchedule.FlightId}");

            var flightScheduleRepository = _unitOfWork.FlightScheduleRepository;
            await flightScheduleRepository.InsertAsync(request.FlightSchedule.ToEntity(), cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static CreateFlightScheduleResponse Result(bool success, string message = null)
        {
            return new CreateFlightScheduleResponse(success, message);
        }
    }
}
