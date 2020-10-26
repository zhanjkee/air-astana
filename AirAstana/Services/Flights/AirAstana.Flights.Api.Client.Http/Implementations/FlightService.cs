using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Client.Contracts;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Flights;
using AirAstana.Flights.Api.Models.Requests.Flights;
using AirAstana.Flights.Options;
using Flurl;
using Flurl.Http;

namespace AirAstana.Flights.Api.Client.Http.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly FlightsOptions _flightsOptions;
        public FlightService(FlightsOptions flightsOptions)
        {
            _flightsOptions = flightsOptions ?? throw new ArgumentNullException(nameof(flightsOptions));
        }

        public async Task<WebResponse<IEnumerable<FlightModel>>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flights")
                .GetJsonAsync<WebResponse<IEnumerable<FlightModel>>>(cancellationToken);
        }

        public async Task<WebResponse<FlightModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/flight/{id}")
                .GetJsonAsync<WebResponse<FlightModel>>(cancellationToken);
        }

        public async Task<WebResponse> CreateAsync(CreateFlightRequest request, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flights", accessToken)
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> UpdateAsync(UpdateFlightRequest request, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flights", accessToken)
                .PutJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> DeleteAsync(int id, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/flights/{id}", accessToken)
                .DeleteAsync(cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        private IFlurlRequest BuildRequest(string segment, string accessToken = null)
        {
            return _flightsOptions.WebAddress.AppendPathSegment(segment).WithOAuthBearerToken(accessToken);
        }
    }
}
