using System;
using AirAstana.Auth.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;

namespace AirAstana.Flights.Service.OnStartup
{
    public static class StartupAuthentication
    {
        public static void AddAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
            });

            services.AddOpenIddict()
                .AddValidation(options =>
                {
                    options.SetIssuer(new Uri(authOptions.Issuer));
                    options.AddEncryptionKey(new SymmetricSecurityKey(Convert.FromBase64String(authOptions.SecretKey)));
                    options.UseAspNetCore();
                    options.UseSystemNetHttp();
                });
        }
    }
}
