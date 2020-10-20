using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Update
{
    public sealed class DeleteFlightCommandHandler : IRequestHandler<UpdateFlightCommand, UpdateFlightResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightCommandHandler([NotNull]IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<UpdateFlightResponse> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            _flightRepository.Update(request.Flight.ToEntity());
            await _flightRepository.SaveChangesAsync(cancellationToken);
            return new UpdateFlightResponse(true);
        }
    }
}
