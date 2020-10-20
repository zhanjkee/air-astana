using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Flights.Update
{
    public sealed class UpdateFlightResponse : ResponseMessage
    {
        public UpdateFlightResponse(bool success, string message = "") : base(success, message)
        {
        }
    }
}
