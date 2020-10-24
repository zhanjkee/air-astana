using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AirAstana.Flights.Service.Filters
{
    public class AuthorizationHeaderOperationFilter : IOperationFilter
    {
        private readonly OpenApiSecurityRequirement _securityRequirement;
        public AuthorizationHeaderOperationFilter(OpenApiSecurityRequirement securityRequirement)
        {
            _securityRequirement = securityRequirement ?? throw new ArgumentNullException(nameof(securityRequirement));
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for authorize attribute
            var hasAuthorize = context.MethodInfo.DeclaringType is { } && (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                                                                           context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any());

            if (!hasAuthorize) return;

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            operation.Security.Add(_securityRequirement);
        }
    }
}