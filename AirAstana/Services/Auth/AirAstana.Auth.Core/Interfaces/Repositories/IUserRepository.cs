using AirAstana.Auth.Domain.Entities;
using AirAstana.Shared.SeedWork;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<bool> CheckPasswordAsync(UserEntity user, string password);
        Task<UserEntity> FindByIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<UserEntity> FindByNameAsync(string userName);        
        Task<IEnumerable<string>> GetRolesAsync(UserEntity user);
        Task<IdentityResult> CreateUserAsync(UserEntity user, string password);
        Task<IdentityResult> UpdateUserAsync(UserEntity user);
    }
}