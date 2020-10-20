using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Locations;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetAll
{
    public sealed class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationsQueryHandler([NotNull] ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return (await _locationRepository.GetAllAsync(cancellationToken)).Select(x => x.ToModel()).ToList();
        }
    }
}
