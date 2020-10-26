using System;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Core.Interfaces.UoW;
using AirAstana.Flights.Core.Mappers;
using AirAstana.Flights.Core.Models.Flights;
using JetBrains.Annotations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetById
{
    public sealed class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, Flight>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFlightQueryHandler([NotNull] IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Flight> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.FlightRepository.GetByIdAsync(request.FlightId)).ToModel();
        }
    }
}
