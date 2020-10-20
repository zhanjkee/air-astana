using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Locations.Create
{
    public sealed class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationResponse>
    {
        private readonly ILocationRepository _locationRepository;
        public CreateLocationCommandHandler([NotNull]ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<CreateLocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationRepository.InsertAsync(request.Location.ToEntity(), cancellationToken);
            await _locationRepository.SaveChangesAsync(cancellationToken);
            return Result(true);
        }

        private static CreateLocationResponse Result(bool success, string message = null)
        {
            return new CreateLocationResponse(success, message);
        }
    }
}
