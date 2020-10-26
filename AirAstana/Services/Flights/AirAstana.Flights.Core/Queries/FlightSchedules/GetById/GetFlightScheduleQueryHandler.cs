using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.FlightSchedules;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetById
{
    public sealed class GetFlightScheduleQueryHandler : IRequestHandler<GetFlightScheduleQuery, FlightSchedule>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlightScheduleQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<FlightSchedule> Handle(GetFlightScheduleQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.FlightScheduleRepository.GetByIdAsync(request.FlightScheduleId)).ToModel();
        }
    }
}
