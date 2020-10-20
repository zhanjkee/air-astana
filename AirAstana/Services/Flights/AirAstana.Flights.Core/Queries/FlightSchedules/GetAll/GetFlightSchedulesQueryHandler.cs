using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.Repositories;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.FlightSchedules;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetAll
{
    public sealed class GetFlightSchedulesQueryHandler : IRequestHandler<GetFlightSchedulesQuery, IEnumerable<FlightSchedule>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightSchedulesQueryHandler([NotNull] IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }

        public async Task<IEnumerable<FlightSchedule>> Handle(GetFlightSchedulesQuery request, CancellationToken cancellationToken)
        {
            var results = request.FromDate.HasValue && request.ToDate.HasValue
                ? await _flightRepository.GetFlightSchedulesAsync(request.FromDate.Value, request.ToDate.Value,
                    request.Asc, cancellationToken)
                : await _flightRepository.GetFlightSchedulesAsync(cancellationToken);
            
            return results.Select(x => x.ToModel()).ToList();
        }
    }
}
