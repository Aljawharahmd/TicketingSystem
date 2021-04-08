using Ticketing.Security.Authentication.Enums;

namespace Ticketing.Security.Authentication.Model
{
    public class TokenUser
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Identifier { get; set; }
        public UserType Type { get; set; }
        public bool TwoStepVerification { get; set; }

    }
}
