using AirAstana.Auth.Api.ActionResults;
using AirAstana.Auth.Api.Models.Common;
using AirAstana.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AirAstana.Auth.Service.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogCritical("LogCritical {0}", context.Exception);

            switch (context.Exception)
            {
                case BadRequestException badRequestException:
                    {
                        var errorMessage = new ErrorMessage
                        {
                            Key = badRequestException.Key,
                            Message = badRequestException.Message,
                            Params = badRequestException.Params
                        };
                        context.Result = new BadRequestObjectResult(new WebResponse(new[] { errorMessage }));
                        break;
                    }
                default:
                    context.Result = new InternalServerErrorObjectResult(new WebResponse(new[]
                    {
                        new ErrorMessage
                        {
                            Message = "Internal server error"
                        }
                    }));
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
