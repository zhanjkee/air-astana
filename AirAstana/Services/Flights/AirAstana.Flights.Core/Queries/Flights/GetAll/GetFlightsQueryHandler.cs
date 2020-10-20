using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Flights;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetAll
{
    public sealed class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightsQueryHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<IEnumerable<Flight>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            return (await _flightRepository.GetAllAsync(cancellationToken)).Select(x => x.ToModel()).ToList();
        }
    }
}
