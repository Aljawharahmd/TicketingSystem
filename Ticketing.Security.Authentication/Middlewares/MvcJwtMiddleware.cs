using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Options;

namespace Ticketing.Security.Authentication.Middlewares
{
    public class MvcJwtMiddleware
    {
        private readonly RequestDelegate _next;

        public MvcJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITokenValidator tokenValidator)
        
        {
            if (!context.Request.Cookies.ContainsKey("Token"))
                await _next.Invoke(context);

            else
            {
                if (!context.Request.Cookies.TryGetValue("Token", out var token) || string.IsNullOrWhiteSpace(token))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    throw new UnauthorizedAccessException("Unauthorized");
                }
                if (tokenValidator.ValidateAndExtract(context, token))
                    await _next.Invoke(context);
                else
                    throw new UnauthorizedAccessException("Unauthorized");
            }
        }
    }
}
