using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Create
{
    public sealed class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreateFlightResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public CreateFlightCommandHandler([NotNull]IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<CreateFlightResponse> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            await _flightRepository.InsertAsync(request.Flight.ToEntity(), cancellationToken);
            await _flightRepository.SaveChangesAsync(cancellationToken);
            return new CreateFlightResponse(true);
        }
    }
}
