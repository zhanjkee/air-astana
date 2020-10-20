using System.Collections.Generic;
using AirAstana.Flights.Core.Models.Flights;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Flights.GetAll
{
    public sealed class GetFlightsQuery : IRequest<IEnumerable<Flight>>
    {
    }
}
