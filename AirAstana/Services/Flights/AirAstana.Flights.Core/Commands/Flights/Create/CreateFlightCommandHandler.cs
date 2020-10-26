using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Create
{
    public sealed class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreateFlightResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFlightCommandHandler([NotNull]IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateFlightResponse> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightRepository = _unitOfWork.FlightRepository;
            await flightRepository.InsertAsync(request.Flight.ToEntity(), cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateFlightResponse(true);
        }
    }
}
