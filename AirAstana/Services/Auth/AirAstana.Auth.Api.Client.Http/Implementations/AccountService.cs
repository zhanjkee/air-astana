using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Client.Contracts;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Api.Models.Responses;

namespace AirAstana.Auth.Api.Client.Http.Implementations
{
    public  class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        ///     Регистрация нового пользователя.
        /// </summary>
        public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request, CancellationToken cancellationToken = default)
        {
            var payload = new RegisterUserResponse(string.Empty);
            try
            {
                using (var responseMessage =
                        await _httpClient.PostAsJsonAsync($"/api/account", request, cancellationToken))
                {
                    // Ignore 409 responses, as they indicate that the account already exists.
                    if (responseMessage.StatusCode == HttpStatusCode.Conflict)
                    {
                        return payload;
                    }

                    responseMessage.EnsureSuccessStatusCode();

                    payload = await responseMessage.Content.ReadFromJsonAsync<RegisterUserResponse>(cancellationToken: cancellationToken);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return payload;
        }

        /// <summary>
        ///     Получить UserInfo.
        /// </summary>
        public async Task<UserInfoResponse> GetUserInfoAsync(AuthTokenResponse authToken, CancellationToken cancellationToken = default)
        {
            var payload = new UserInfoResponse(string.Empty, false, new Claim[0]);
            try
            {
                var requestMessage =
                    new HttpRequestMessage(HttpMethod.Get, $"/connect/userinfo");

                requestMessage.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                if (authToken != null)
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken.AccessToken);
                }

                using (var responseMessage = await _httpClient.SendAsync(requestMessage,
                    HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    responseMessage.EnsureSuccessStatusCode();

                    payload = await responseMessage.Content.ReadFromJsonAsync<UserInfoResponse>(
                        cancellationToken: cancellationToken);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return payload;
        }
    }
}
