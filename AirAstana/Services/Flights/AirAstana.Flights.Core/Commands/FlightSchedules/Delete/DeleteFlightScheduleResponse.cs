using AirAstana.Flights.Core.Models;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Delete
{
    public sealed class DeleteFlightScheduleResponse : ResponseMessage
    {
        public DeleteFlightScheduleResponse(bool success, string message = null) : base(success, message)
        {
        }
    }
}
