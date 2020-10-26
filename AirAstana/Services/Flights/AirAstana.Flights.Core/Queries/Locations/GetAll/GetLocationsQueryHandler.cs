using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Locations;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetAll
{
    public sealed class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLocationsQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.LocationRepository.GetAllAsync(cancellationToken)).Select(x => x.ToModel()).ToList();
        }
    }
}
