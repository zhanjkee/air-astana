using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Delete
{
    public sealed class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationResponse>
    {
        private readonly ILocationRepository _locationRepository;
        public DeleteLocationCommandHandler([NotNull]ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<DeleteLocationResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetByIdAsync(request.LocationId, cancellationToken);
            if (location == null) return Result(false, $"Location does not exists by id: {request.LocationId}");

            _locationRepository.Delete(location);
            await _locationRepository.SaveChangesAsync(cancellationToken);

            return Result(true);
        }

        private static DeleteLocationResponse Result(bool success, string message = null)
        {
            return new DeleteLocationResponse(success, message);
        }
    }
}
