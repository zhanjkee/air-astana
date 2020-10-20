using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.Delete
{
    public sealed class DeleteFlightScheduleCommand : IRequest<DeleteFlightScheduleResponse>
    {
        public int FlightScheduleId { get; set; }
        public DeleteFlightScheduleCommand(int flightScheduleId)
        {
            FlightScheduleId = flightScheduleId;
        }
    }
}
