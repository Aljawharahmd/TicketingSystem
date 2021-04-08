using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ticketing.Security.Authentication.Abstractions;

namespace Ticketing.Security.Authentication.Middlewares
{
    public class ApiJwtMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserManagerAuthentication authenticationManager, ITokenValidator tokenValidator)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token))
                await tokenValidator.ValidateAndExtract(context,authenticationManager, token);
            await _next(context);
        }
    }
}
