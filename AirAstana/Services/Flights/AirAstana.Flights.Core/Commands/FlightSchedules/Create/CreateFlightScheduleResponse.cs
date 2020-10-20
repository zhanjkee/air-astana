using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Create
{
    public sealed class CreateFlightScheduleResponse : ResponseMessage
    {
        public CreateFlightScheduleResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
