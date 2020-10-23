using AirAstana.Auth.Data;
using AirAstana.Auth.Data.Entities;
using AirAstana.Auth.Options;
using AirAstana.Auth.Service.AutofacModules;
using AirAstana.Shared.Extensions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace AirAstana.Auth.Service
{
    public class Startup
    {
        /// <summary>
        ///     The API version.
        /// </summary>
        public static readonly string ApiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AuthOptions = configuration.GetValidOptions<AuthOptions>(AuthOptions.SectionName);
        }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     Gets the autofac container.
        /// </summary>
        public ILifetimeScope AutofacContainer { get; private set; }

        /// <summary>
        ///     Gets the auth options.
        /// </summary>
        public AuthOptions AuthOptions { get; }

        /// <summary>
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
                options.MapDefaultControllerRoute();
            });
        }

        /// <summary>
        ///     Configures the container.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AuthModule());
        }

        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(AuthOptions.ConnectionString);

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            // Register the Identity services.
            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = Claims.Role;
            });

            services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<ApplicationDbContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options.SetTokenEndpointUris("/connect/token");

                    // Enable the password and the refresh token flows.
                    options.AllowPasswordFlow()
                           .AllowRefreshTokenFlow();

                    // Accept anonymous clients (i.e clients that don't send a client_id).
                    options.AcceptAnonymousClients();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                           .EnableTokenEndpointPassthrough()
                           .DisableTransportSecurityRequirement(); // During development, you can disable the HTTPS requirement.
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

            //services.AddAuthorization();
        }
    }
}
