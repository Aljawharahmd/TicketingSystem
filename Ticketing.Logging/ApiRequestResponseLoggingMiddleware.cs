using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ticketing.Trace.Abstraction;

namespace Ticketing.Logging
{
    /// <summary>
    /// Using for Api to record requests and responses and exceptions
    /// for more information, visit https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
    /// </summary>
    public class ApiRequestResponseLoggingMiddleware
    {
        private readonly ILogger<ApiRequestResponseLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ApiRequestResponseLoggingMiddleware(ILogger<ApiRequestResponseLoggingMiddleware> logger, RequestDelegate next)
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
                await LogRequestData(context, requestId);
                var originalBodyStream = context.Response.Body;
                await using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                await LogResponseData(context.Response, requestId);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, requestId + ": " + exception.Message);
            }
        }
        private async Task LogRequestData(HttpContext context, Guid requestId)
        {
            context.Request.EnableBuffering();
            var body = context.Request.Body;
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            context.Request.Body.Position = 0;
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            context.Request.Body = body;

            _logger.LogDebug($"Request information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Scheme: {context.Request.Scheme}{Environment.NewLine}" +
                             $"Host: {context.Request.Host}{Environment.NewLine}" +
                             $"Path: {context.Request.Path}{Environment.NewLine}" +
                             $"QueryString: {context.Request.QueryString}{Environment.NewLine}" +
                             $"Body: {bodyAsText}" +
                             $"{Environment.NewLine}{Environment.NewLine}");
        }
        private async Task LogResponseData(HttpResponse response, Guid requestId)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            _logger.LogDebug($"Response information:{Environment.NewLine}" +
                             $"requestId: {requestId}" +
                             $"Status Code: {response.StatusCode}" +
                             $"text: {text}");
        }

    }
}
