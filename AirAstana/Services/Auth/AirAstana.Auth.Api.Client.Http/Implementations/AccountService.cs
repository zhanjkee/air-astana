using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
        private readonly string _webAddress;
        public AccountService(HttpClient httpClient, string webAddress)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrEmpty(webAddress)) throw new ArgumentNullException(nameof(webAddress));

            _webAddress = webAddress;
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
                        await _httpClient.PostAsJsonAsync($"{_webAddress}/api/account", request, cancellationToken))
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
    }
}
