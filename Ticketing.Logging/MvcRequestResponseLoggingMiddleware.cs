using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ticketing.Trace.Abstraction;

namespace Ticketing.Logging
{
    /// <summary>
    /// Using for Mvc to record requests and responses and exceptions
    /// for more information, visit https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
    /// </summary>
    public class MvcRequestResponseLoggingMiddleware
    {
        private readonly ILogger<MvcRequestResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public MvcRequestResponseLoggingMiddleware(ILogger<MvcRequestResponseLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IRequestTrace requestTracer)
        {
            var requestId = Guid.NewGuid();
            requestTracer.Register(requestId);
            try
            {
                LogRequestData(context, requestId);

                await _next(context);

                LogResponseData(context, requestId);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, requestId + ": " + exception.Message);
            }
        }
        private void LogRequestData(HttpContext context, Guid requestId)
        {
            _logger.LogDebug($"Request information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Scheme: {context.Request.Scheme}{Environment.NewLine}" +
                             $"Host: {context.Request.Host}{Environment.NewLine}" +
                             $"Path: {context.Request.Path}{Environment.NewLine}" +
                             $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }
        private void LogResponseData(HttpContext context, Guid requestId)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            _logger.LogDebug($"Response information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Status Code: {context.Response.StatusCode}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }

    }
}
