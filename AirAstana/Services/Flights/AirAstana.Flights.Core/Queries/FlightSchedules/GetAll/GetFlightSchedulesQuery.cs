using System;
using System.Collections.Generic;
using AirAstana.Flights.Core.Models.FlightSchedules;
using MediatR;

namespace AirAstana.Flights.Core.Queries.FlightSchedules.GetAll
{
    public sealed class GetFlightSchedulesQuery : IRequest<IEnumerable<FlightSchedule>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool Asc { get; set; }

        public GetFlightSchedulesQuery(DateTime? fromDate, DateTime? toDate, bool asc = true)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Asc = asc;
        }
    }
}
