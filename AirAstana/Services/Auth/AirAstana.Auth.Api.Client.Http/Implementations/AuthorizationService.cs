using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Client.Contracts;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Api.Models.Responses;
using AirAstana.Shared.Extensions;

namespace AirAstana.Auth.Api.Client.Http.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _webAddress;
        public AuthorizationService(HttpClient httpClient, string webAddress)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrEmpty(webAddress)) throw new ArgumentNullException(nameof(webAddress));

            _webAddress = webAddress;
        }

        /// <summary>
        ///     Авторизоваться.
        /// </summary>
        public async Task<AuthTokenResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            AuthTokenResponse payload;
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_webAddress}/connect/token")
                {
                    Content = new FormUrlEncodedContent(request.ToKeyValue())
                };
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var responseMessage = await _httpClient.SendAsync(requestMessage,
                    HttpCompletionOption.ResponseContentRead, cancellationToken))
                {
                    responseMessage.EnsureSuccessStatusCode();

                    payload = await responseMessage.Content.ReadFromJsonAsync<AuthTokenResponse>(
                        cancellationToken: cancellationToken);
                }
            }
            catch (Exception exception)
            {
                payload = new AuthTokenResponse(string.Empty, string.Empty, string.Empty, 0, string.Empty, exception.Message);
            }
            return payload;
        }

        /// <summary>
        ///     Обновить токен.
        /// </summary>
        public async Task<AuthTokenResponse> RefreshTokenAsync(RefreshGrantRequest request, CancellationToken cancellationToken = default)
        {
            AuthTokenResponse payload;
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_webAddress}/connect/token")
                {
                    Content = new FormUrlEncodedContent(request.ToKeyValue())
                };
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var responseMessage = await _httpClient.SendAsync(requestMessage,
                    HttpCompletionOption.ResponseContentRead, cancellationToken))
                {
                    responseMessage.EnsureSuccessStatusCode();

                    payload = await responseMessage.Content.ReadFromJsonAsync<AuthTokenResponse>(
                        cancellationToken: cancellationToken);
                }
            }
            catch (Exception exception)
            {
                payload = new AuthTokenResponse(string.Empty, string.Empty, string.Empty, 0, string.Empty, exception.Message);
            }
            return payload;
        }
    }
}
