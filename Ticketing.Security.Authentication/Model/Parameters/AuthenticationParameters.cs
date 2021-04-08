using Ticketing.Security.Authentication.Enums;

namespace Ticketing.Security.Authentication.Model.Parameters
{
    public class AuthenticationParameters
    {
        public string Identifier { get; set; }
        public string AreaCode { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
    }
}
