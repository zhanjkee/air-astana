using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Delete
{
    public sealed class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, DeleteFlightResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFlightCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<DeleteFlightResponse> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flightRepository = _unitOfWork.FlightRepository;
            flightRepository.Delete(request.FlightId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteFlightResponse(true);
        }
    }
}
