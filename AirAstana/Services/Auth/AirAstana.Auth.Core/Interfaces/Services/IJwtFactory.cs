using AirAstana.Auth.Core.Models;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Interfaces.Services
{
    /// <summary>
    ///     Фабрика для создания закодированного токена.
    /// </summary>
    public interface IJwtFactory
    {
        AccessToken GenerateEncodedToken(UserInfo userInfo, string clientId);
        Task<AccessToken> GenerateEncodedTokenAsync(UserInfo userInfo, string clientId);
    }
}
