using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Locations;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetById
{
    public sealed class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Location>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationQueryHandler([NotNull] ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<Location> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            return (await _locationRepository.GetByIdAsync(request.LocationId)).ToModel();
        }
    }
}
