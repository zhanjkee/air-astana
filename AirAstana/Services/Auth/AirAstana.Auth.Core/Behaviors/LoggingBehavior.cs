using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using AirAstana.Shared.Extensions;

namespace AirAstana.Auth.Core.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling request {RequestName} ({@RequestParams})", request.GetGenericTypeName(), request);
            var response = await next();
            _logger.LogInformation("----- Request {RequestName} handled - response: {@Response}", request.GetGenericTypeName(), response);

            return response;
        }
    }
}
