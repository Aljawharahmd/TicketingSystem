using System.Collections.Generic;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.Security.Authentication.Model.Results
{
    public class AuthenticationContext
    {
        public int UserId { get; set; }
        public string Identifier { get; set; }
        public UserType Type { get; set; }
        public IEnumerable<AuthenticationMethod> RequiredMethods { get; set; } = new List<AuthenticationMethod>();
    }
}
