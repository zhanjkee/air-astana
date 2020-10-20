using AirAstana.Flights.Core.Models.Locations;
using MediatR;

namespace AirAstana.Flights.Core.Queries.Locations.GetById
{
    public sealed class GetLocationQuery : IRequest<Location>
    {
        public int LocationId { get; set; }

        public GetLocationQuery(int locationId)
        {
            LocationId = locationId;
        }
    }
}
