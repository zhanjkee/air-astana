using AirAstana.Auth.Core.Interfaces.Repositories;
using AirAstana.Auth.Data.Context;
using AirAstana.Auth.Data.Specifications;
using AirAstana.Auth.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirAstana.Auth.Data.Repositories
{
    public class UserRepository : EfRepository<UserEntity>, IUserRepository
    {
        [NotNull]
        private readonly UserManager<UserEntity> _userManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <exception cref="ArgumentNullException">userManager</exception>
        public UserRepository([NotNull] UserManager<UserEntity> userManager, ApplicationDbContext context)
            : base(context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<UserEntity> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<UserEntity> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return (await GetAsync(new UserSpecification(userId), cancellationToken)).SingleOrDefault();
        }

        public async Task<bool> CheckPasswordAsync(UserEntity user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(UserEntity user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> CreateUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserAsync(UserEntity user)
        {
            return await _userManager.UpdateAsync(user);
        }        
    }
}
