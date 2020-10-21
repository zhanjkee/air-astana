using AirAstana.Flights.Core.Models.Flights;
using MediatR;

namespace AirAstana.Flights.Core.Commands.Flights.Update
{
    public sealed class UpdateFlightCommand : IRequest<UpdateFlightResponse>
    {
        public Flight Flight { get; set; }

        public UpdateFlightCommand(Flight flight)
        {
            Flight = flight;
        }
    }
}
