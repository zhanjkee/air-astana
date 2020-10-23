using System.Threading;
using System.Threading.Tasks;
using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Api.Models.Responses;

namespace AirAstana.Auth.Api.Client.Contracts
{
    public interface IAccountService
    {
        /// <summary>
        ///     Регистрация нового пользователя.
        /// </summary>
        Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request, CancellationToken cancellationToken = default);
    }
}