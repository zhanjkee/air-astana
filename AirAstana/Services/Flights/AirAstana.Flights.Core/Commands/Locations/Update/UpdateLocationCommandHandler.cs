using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Update
{
    public sealed class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationResponse>
    {
        private readonly ILocationRepository _locationRepository;
        public UpdateLocationCommandHandler([NotNull]ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<UpdateLocationResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetByIdAsync(request.Location.Id);
            if (location == null) return Result(false, $"Location does not exists by id: {request.Location.Id}");

            _locationRepository.Update(request.Location.ToEntity());
            await _locationRepository.SaveChangesAsync(cancellationToken);
            return Result(true);
        }

        private static UpdateLocationResponse Result(bool success, string message = null)
        {
            return new UpdateLocationResponse(success, message);
        }
    }
}
