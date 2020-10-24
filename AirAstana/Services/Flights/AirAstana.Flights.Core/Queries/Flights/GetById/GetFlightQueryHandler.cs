using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Flights;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetById
{
    public sealed class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, Flight>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightQueryHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<Flight> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            return (await _flightRepository.GetFlightByIdAsync(request.FlightId, cancellationToken)).ToModel();
        }
    }
}
