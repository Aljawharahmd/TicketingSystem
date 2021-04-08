using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ticketing.Security.Authentication.Abstractions
{
    public interface ITokenValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateAndExtract(HttpContext context, string token);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManagerAuthenticationManager"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> ValidateAndExtract(HttpContext context, IUserManagerAuthentication userManagerAuthenticationManager, string token);
    }
}
