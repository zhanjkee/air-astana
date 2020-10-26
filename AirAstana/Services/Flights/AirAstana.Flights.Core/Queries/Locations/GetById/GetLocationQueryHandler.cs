using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Locations;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetById
{
    public sealed class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Location>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLocationQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Location> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.LocationRepository.GetByIdAsync(request.LocationId)).ToModel();
        }
    }
}
