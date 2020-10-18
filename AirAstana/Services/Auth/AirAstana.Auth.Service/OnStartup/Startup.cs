using AirAstana.Auth.Options;
using AirAstana.Auth.Service.AutofacModules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AirAstana.Shared.Extensions;

namespace AirAstana.Auth.Service.OnStartup
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
            ServiceOptions = configuration.GetValidOptions<ServiceOptions>(ServiceOptions.SectionName);
            JwtIssuerOptions = configuration.GetValidOptions<JwtIssuerOptions>(JwtIssuerOptions.SectionName);
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ServiceOptions.SecretKey));
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
        ///     Gets the service options.
        /// </summary>
        public ServiceOptions ServiceOptions { get; }

        /// <summary>
        ///     Gets the JWT issuer options.
        /// </summary>
        public JwtIssuerOptions JwtIssuerOptions { get; }

        /// <summary>
        ///     Gets the issuer signing key.
        /// </summary>
        public SecurityKey IssuerSigningKey { get; }

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
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "AirAstana auth service");
                c.RoutePrefix = "swagger";
            });

            app.UseAuthentication();

            app.UseRouting();

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
            builder.RegisterModule(new AuthModule());
        }

        /// <summary>
        ///     Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddControllers();
            services.AddSwagger(ApiVersion);
            services.AddAuthentication(JwtIssuerOptions, IssuerSigningKey);
        }
    }
}
