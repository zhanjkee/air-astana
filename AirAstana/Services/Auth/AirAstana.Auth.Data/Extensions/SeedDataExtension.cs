using AirAstana.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace AirAstana.Auth.Data.Extensions
{
    internal static class SeedDataExtension
    {
        public static void SeedData(this ModelBuilder builder)
        {
            var adminUserId = Guid.NewGuid().ToString();
            var moderatorUserId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();
            var moderatorRoleId = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<UserEntity>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole[]
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                },
                new IdentityRole
                {
                    Id = moderatorRoleId,
                    Name = "Moderator",
                    NormalizedName = "Moderator"
                }
            });

            builder.Entity<UserEntity>().HasData(new UserEntity[]
            {
                new UserEntity(string.Empty, string.Empty, "admin", "kalkenov.zh@gmail.com")
                {
                    Id = adminUserId,
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "test"),
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                },
                new UserEntity(string.Empty, string.Empty, "moderator", "kalkenov.zh@gmail.com")
                {
                    Id = moderatorUserId,
                    NormalizedUserName = "moderator",
                    PasswordHash = hasher.HashPassword(null, "test"),
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                }
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                },
                 new IdentityUserRole<string>
                {
                     RoleId = moderatorRoleId,
                     UserId = moderatorUserId
                }
            });
        }
    }
}
