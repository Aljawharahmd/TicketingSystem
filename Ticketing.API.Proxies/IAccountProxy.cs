using System.Threading.Tasks;
using Refit;
using Ticketing.Security.Authentication.Model.Parameters;
using Ticketing.Security.Authentication.Model.Results;

namespace Ticketing.API.Proxies
{
    public interface IAccountProxy
    {
        [Post("/api/accounts/authenticate")]
        Task<AuthenticationContext>  Authenticate(AuthenticationParameters parameters);

        [Post("/api/accounts/generateToken")]
        Task<string> GenerateToken(AuthenticationContext context);
    }
}
