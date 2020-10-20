using AirAstana.Flights.Core.Models.Flights;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Create
{
    public sealed class CreateFlightCommand : IRequest<CreateFlightResponse>
    {
        public Flight Flight { get; set; }

        public CreateFlightCommand(Flight flight)
        {
            Flight = flight;
        }
    }
}
