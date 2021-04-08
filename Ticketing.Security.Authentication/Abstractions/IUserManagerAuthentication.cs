using System.Threading.Tasks;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model.Parameters;
using Ticketing.Security.Authentication.Model.Results;

namespace Ticketing.Security.Authentication.Abstractions
{
    /// <summary>
    ///The proxy searches for and prepares the user information(whether it's staff of client)
    /// and returns the authentication context
    /// the login authentication parameters to determine the user type and prepare context
    /// Parameters are the identifier, area code, password, and user type
    /// </summary>
    public interface IUserManagerAuthentication
    {

        Task<AuthenticationContext> Get(AuthenticationParameters parameters);
        Task<AuthenticationContext> Get(int id, UserType type);
    }
}
