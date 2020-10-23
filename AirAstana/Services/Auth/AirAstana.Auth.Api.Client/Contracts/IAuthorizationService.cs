using System.Threading;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Api.Models.Responses;

namespace AirAstana.Auth.Api.Client.Contracts
{
    public interface IAuthorizationService
    {
        /// <summary>
        ///     Авторизоваться.
        /// </summary>
        Task<AuthTokenResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Обновить токен.
        /// </summary>
        Task<AuthTokenResponse> RefreshTokenAsync(RefreshGrantRequest request, CancellationToken cancellationToken = default);
    }
}
