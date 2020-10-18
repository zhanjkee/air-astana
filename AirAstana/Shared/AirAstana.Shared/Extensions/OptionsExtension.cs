using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AirAstana.Shared.Validators;
using Microsoft.Extensions.Configuration;

namespace AirAstana.Shared.Extensions
{
    public static class OptionsExtension
    {
        public static TOptions GetValidOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : class
        {
            var instance = Activator.CreateInstance<TOptions>();

            configuration.GetSection(sectionName).Bind(instance);

            if (!DataAnnotationsValidator.TryValidate(instance, out var validationResults))
            {
                var validationExceptions = validationResults.Select(x => new ValidationException(x.ErrorMessage));
                var aggregatedException = new AggregateException(validationExceptions);

                throw new InvalidOperationException($"Unable to build {typeof(TOptions).Name}", aggregatedException);
            }

            return instance;
        }
    }
}
