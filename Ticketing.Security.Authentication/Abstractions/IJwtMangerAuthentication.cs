using System.Threading.Tasks;
using Ticketing.Security.Authentication.Model.Results;

namespace Ticketing.Security.Authentication.Abstractions
{
    public interface IJwtMangerAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<string> GenerateToken(AuthenticationContext context);
    }
}
