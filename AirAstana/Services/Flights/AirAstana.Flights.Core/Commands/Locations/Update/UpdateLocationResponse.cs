using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Locations.Update
{
    public sealed class UpdateLocationResponse : ResponseMessage
    {
        public UpdateLocationResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
