using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.FlightSchedules;
using AirAstana.Flights.Core.Specifications;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetAll
{
    public sealed class GetFlightSchedulesQueryHandler : IRequestHandler<GetFlightSchedulesQuery, IEnumerable<FlightSchedule>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlightSchedulesQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<FlightSchedule>> Handle(GetFlightSchedulesQuery request, CancellationToken cancellationToken)
        {
            var flightScheduleRepository = _unitOfWork.FlightScheduleRepository;

            var results = !request.FromDate.HasValue || !request.ToDate.HasValue
                ? await flightScheduleRepository.GetAllAsync(cancellationToken)
                : await flightScheduleRepository.GetAsync(
                    new FlightScheduleSpecification(x =>
                        x.Departure >= request.FromDate && x.Departure <= request.ToDate), cancellationToken);

            return (request.Asc
                    ? results.OrderBy(x => x.Departure)
                    : results.OrderByDescending(x => x.Departure)).Select(x => x.ToModel()).ToList();
        }
    }
}
