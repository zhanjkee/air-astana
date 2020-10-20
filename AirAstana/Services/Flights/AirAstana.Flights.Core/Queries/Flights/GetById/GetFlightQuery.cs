using AirAstana.Flights.Core.Models.Flights;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetById
{
    public sealed class GetFlightQuery : IRequest<Flight>
    {
        public int FlightId { get; set; }

        public GetFlightQuery(int flightId)
        {
            FlightId = flightId;
        }
    }
}
