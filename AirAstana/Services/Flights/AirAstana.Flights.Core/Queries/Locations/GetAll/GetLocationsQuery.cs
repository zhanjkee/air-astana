using System.Collections.Generic;
using AirAstana.Flights.Core.Models.Locations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetAll
{
    public sealed class GetLocationsQuery : IRequest<IEnumerable<Location>>
    {
    }
}
