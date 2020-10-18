using AirAstana.Auth.Api.Controllers;
using AirAstana.Auth.Api.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AirAstana.Auth.Service.OnStartup
{
    public static class StartupSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string apiVersion)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(apiVersion, new OpenApiInfo
                {
                    Version = apiVersion,
                    Title = "AirAstana auth service",
                    TermsOfService = new Uri("https://airastana.com"),
                });

                var apiXmlFile = $"{Assembly.GetAssembly(typeof(BaseController)).GetName().Name}.xml";
                var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
                setupAction.IncludeXmlComments(apiXmlPath);

                var apiModelXmlFile = $"{Assembly.GetAssembly(typeof(LoginResponse)).GetName().Name}.xml";
                var apiModelXmlPath = Path.Combine(AppContext.BaseDirectory, apiModelXmlFile);
                setupAction.IncludeXmlComments(apiModelXmlPath);

                setupAction.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}
