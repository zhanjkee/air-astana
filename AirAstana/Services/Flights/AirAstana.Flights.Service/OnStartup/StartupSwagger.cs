using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AirAstana.Flights.Api.Controllers;
using AirAstana.Flights.Api.Models.Requests.Flights;
using AirAstana.Flights.Service.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AirAstana.Flights.Service.OnStartup
{
    public static class StartupSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string apiVersion, string authAddress)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(apiVersion, new OpenApiInfo
                {
                    Version = apiVersion,
                    Title = "AirAstana flights service",
                    TermsOfService = new Uri("https://airastana.com"),
                });

                var apiXmlFile = $"{Assembly.GetAssembly(typeof(BaseController))?.GetName().Name}.xml";
                var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
                setupAction.IncludeXmlComments(apiXmlPath);

                var apiModelXmlFile = $"{Assembly.GetAssembly(typeof(CreateFlightRequest))?.GetName().Name}.xml";
                var apiModelXmlPath = Path.Combine(AppContext.BaseDirectory, apiModelXmlFile);
                setupAction.IncludeXmlComments(apiModelXmlPath);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.OAuth2,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    },
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(authAddress),
                            TokenUrl = new Uri(authAddress),
                        },

                    },
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = JwtBearerDefaults.AuthenticationScheme,
                            In = ParameterLocation.Header,
                            Scheme = "oauth2",
                            Reference = new OpenApiReference
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme
                            },
                        },
                        new List<string>()
                    }
                };

                setupAction.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                setupAction.AddSecurityRequirement(securityRequirement);
                setupAction.OperationFilter<AuthorizationHeaderOperationFilter>(securityRequirement);
                setupAction.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}
