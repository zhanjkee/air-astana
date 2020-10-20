using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Delete
{
    public sealed class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, DeleteFlightResponse>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightCommandHandler([NotNull]IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<DeleteFlightResponse> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            await _flightRepository.DeleteAsync(request.FlightId, cancellationToken);
            await _flightRepository.SaveChangesAsync(cancellationToken);
            return new DeleteFlightResponse(true);
        }
    }
}
