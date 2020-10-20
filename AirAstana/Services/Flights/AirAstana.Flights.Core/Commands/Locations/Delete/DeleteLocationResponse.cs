using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Locations.Delete
{
    public sealed class DeleteLocationResponse : ResponseMessage
    {
        public DeleteLocationResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
