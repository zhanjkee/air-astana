using System.Linq;
using AirAstana.Auth.Options;
using AirAstana.Flights.Options;
using AirAstana.Flights.Service.AutofacModules;
using AirAstana.Flights.Service.Filters;
using AirAstana.Shared.Extensions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AirAstana.Flights.Service.OnStartup
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
            FlightOptions = configuration.GetValidOptions<FlightsOptions>(FlightsOptions.SectionName);
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
        ///     Gets the flight service options.
        /// </summary>
        public FlightsOptions FlightOptions { get; }

        /// <summary>
        ///     Gets the auth service options.
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "AirAstana flights service");
                c.RoutePrefix = "swagger";
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        ///     Configures the container.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new FlightsModule());
        }

        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger(ApiVersion, AuthOptions.WebAddress);
            services.AddAuthentication(AuthOptions);
            services.AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                }).AddNewtonsoftJson();
        }
    }
}
