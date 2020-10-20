using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Delete
{
    public sealed class DeleteFlightCommand : IRequest<DeleteFlightResponse>
    {
        public int FlightId { get; set; }
    }
}
