using MediatR;

namespace AirAstana.Flights.Core.Commands.FlightSchedules.AddDelay
{
    public sealed class AddDelayFlightScheduleCommand : IRequest<AddDelayFlightScheduleResponse>
    {
        public int FlightScheduleId { get; set; }
        public long DelayTicks { get; set; }
        public AddDelayFlightScheduleCommand(int flightScheduleId, long delayTiks)
        {
            FlightScheduleId = flightScheduleId;
            DelayTicks = delayTiks;
        }
    }
}
