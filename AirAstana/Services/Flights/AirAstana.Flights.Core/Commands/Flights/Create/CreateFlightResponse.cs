using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Flights.Create
{
    public sealed class CreateFlightResponse : ResponseMessage
    {
        public CreateFlightResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
