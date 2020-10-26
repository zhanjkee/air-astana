using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Update
{
    public sealed class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, UpdateFlightResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFlightCommandHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UpdateFlightResponse> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightRepository = _unitOfWork.FlightRepository;
            flightRepository.Update(request.Flight.ToEntity());
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new UpdateFlightResponse(true);
        }
    }
}
