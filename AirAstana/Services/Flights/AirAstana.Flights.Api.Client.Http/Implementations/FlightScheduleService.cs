using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Client.Contracts;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Api.Models.Requests.FlightSchedules;
using AirAstana.Flights.Options;
using Flurl;
using Flurl.Http;

namespace AirAstana.Flights.Api.Client.Http.Implementations
{
    public class FlightScheduleService : IFlightScheduleService
    {
        private readonly FlightsOptions _flightsOptions;
        public FlightScheduleService(FlightsOptions flightsOptions)
        {
            _flightsOptions = flightsOptions ?? throw new ArgumentNullException(nameof(flightsOptions));
        }

        public async Task<WebResponse<IEnumerable<FlightScheduleModel>>> GetAsync(GetFlightSchedulesRequest request, CancellationToken cancellationToken = default)
        {
            if (request.FromDate.HasValue == false && request.ToDate.HasValue == false)
            {
                return await BuildRequest("api/flightSchedules").GetJsonAsync<WebResponse<IEnumerable<FlightScheduleModel>>>(cancellationToken);
            }

            return await BuildRequest("api/flightSchedules")
                .SetQueryParam("fromDate", request.FromDate)
                .SetQueryParam("toDate", request.ToDate)
                .SetQueryParam("asc", request.Asc)
                .GetJsonAsync<WebResponse<IEnumerable<FlightScheduleModel>>>(cancellationToken);
        }

        public async Task<WebResponse<FlightScheduleModel>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/flightSchedules/{id}")
                .GetJsonAsync<WebResponse<FlightScheduleModel>>(cancellationToken);
        }

        public async Task<WebResponse> CreateAsync(CreateFlightScheduleRequest request, string accessToken,
            CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flightSchedules", accessToken)
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> AddDelayTimeAsync(AddDelayFlightScheduleRequest request, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flightSchedules/delay", accessToken)
                .PatchJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> UpdateAsync(UpdateFlightScheduleRequest request, string accessToken,
            CancellationToken cancellationToken = default)
        {
            return await BuildRequest("api/flightSchedules", accessToken)
                .PutJsonAsync(request, cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        public async Task<WebResponse> DeleteAsync(int id, string accessToken, CancellationToken cancellationToken = default)
        {
            return await BuildRequest($"api/flightSchedules/{id}", accessToken)
                .DeleteAsync(cancellationToken)
                .ReceiveJson<WebResponse>();
        }

        private IFlurlRequest BuildRequest(string segment, string accessToken = null)
        {
            return _flightsOptions.WebAddress.AppendPathSegment(segment).WithOAuthBearerToken(accessToken);
        }
    }
}
