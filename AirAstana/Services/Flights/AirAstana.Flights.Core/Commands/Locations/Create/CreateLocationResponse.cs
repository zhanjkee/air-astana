using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.Locations.Create
{
    public sealed class CreateLocationResponse : ResponseMessage
    {
        public CreateLocationResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
