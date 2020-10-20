using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Update
{
    public sealed class UpdateFlightScheduleResponse : ResponseMessage
    {
        public UpdateFlightScheduleResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
