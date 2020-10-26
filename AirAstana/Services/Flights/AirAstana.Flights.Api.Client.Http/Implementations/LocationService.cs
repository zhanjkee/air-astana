using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Client.Contracts;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Locations;
using AirAstana.Flights.Api.Models.Requests.Locations;
using AirAstana.Flights.Options;
using Flurl;
using Flurl.Http;

namespace AirAstana.Flights.Api.Client.Http.Implementations
{
    public sealed class LocationService : ILocationService
    {
        private readonly FlightsOptions _flightsOptions;
        public LocationService(FlightsOptions flightsOptions)
        {
            _flightsOptions = flightsOptions ?? throw new ArgumentNullException(nameof(flightsOptions));
        }

        public async Task<WebResponse<IEnumerable<LocationModel>>> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/locations")
                .GetJsonAsync<WebResponse<IEnumerable<LocationModel>>>(cancellationToken);
        }

        public async Task<WebResponse<LocationModel>> GetLocationByIdAsync(int locationId, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/locations/{locationId}")
                .GetJsonAsync<WebResponse<LocationModel>>(cancellationToken);
        }

        public async Task<WebResponse> CreateAsync(CreateLocationRequest request, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/locations", accessToken)
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> UpdateAsync(UpdateLocationRequest request, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/locations", accessToken)
                .PutJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> DeleteAsync(int locationId, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/locations/{locationId}", accessToken)
                .DeleteAsync(cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        private IFlurlRequest BuildRequest(string segment, string accessToken = null)
        {
            return _flightsOptions.WebAddress.AppendPathSegment(segment).WithOAuthBearerToken(accessToken);
        }
    }
}
