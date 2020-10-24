using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.AddDelay
{
    public sealed class AddDelayFlightScheduleResponse : ResponseMessage
    {
        public AddDelayFlightScheduleResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
