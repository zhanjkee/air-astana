using System;
using AirAstana.Auth.Data.Entities;
using AirAstana.Auth.Data.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirAstana.Auth.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext([NotNull]DbContextOptions options) : base(options)
        {
            //TODO: Use migration instead of below.
            Database.EnsureCreated();
        }

        private ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dateTimeUtcConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            modelBuilder.UseValueConverterForType<DateTime>(dateTimeUtcConverter);
            modelBuilder.SeedData();
        }
    }
}
