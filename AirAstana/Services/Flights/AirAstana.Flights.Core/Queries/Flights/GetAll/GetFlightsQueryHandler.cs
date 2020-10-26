using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Flights;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetAll
{
    public sealed class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlightsQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Flight>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.FlightRepository.GetAllAsync(cancellationToken)).Select(x => x.ToModel()).ToList();
        }
    }
}
