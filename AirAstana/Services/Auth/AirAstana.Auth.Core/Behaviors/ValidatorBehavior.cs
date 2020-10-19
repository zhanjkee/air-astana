using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Shared.Extensions;
using AirAstana.Shared.Exceptions;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;

namespace AirAstana.Auth.Core.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();

            _logger.LogInformation("----- Validating request {CommandType}", typeName);

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogWarning("Validation errors - {CommandType} - Request: {@Command} - Errors: {@ValidationErrors}", typeName, request, failures);

                throw new BadRequestException(GetValidationErrorText(failures));
            }

            return await next();
        }

        private static string GetValidationErrorText(List<ValidationFailure> errors)
        {
            var sb = new StringBuilder();
            foreach (var error in errors) 
                sb.Append(error.ErrorMessage)
                    .AppendLine();

            return sb.ToString();
        }
    }
}