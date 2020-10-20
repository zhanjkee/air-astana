using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Flights.Delete
{
    public sealed class DeleteFlightResponse : ResponseMessage
    {
        public DeleteFlightResponse(bool success, string message = "") : base(success, message)
        {
        }
    }
}
