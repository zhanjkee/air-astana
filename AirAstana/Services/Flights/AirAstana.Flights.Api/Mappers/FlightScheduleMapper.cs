using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Core.Models.FlightSchedules;

namespace AirAstana.Flights.Api.Mappers
{
    public static class FlightScheduleMapper
    {
        public static FlightScheduleModel ToApiModel(this FlightSchedule flightSchedule)
        {
            if (flightSchedule == null) return null;
            return new FlightScheduleModel
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId
            };
        }

        public static FlightSchedule ToCoreModel(this FlightScheduleModel flightSchedule)
        {
            if (flightSchedule == null) return null;
            return new FlightSchedule
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId
            };
        }
    }
}
