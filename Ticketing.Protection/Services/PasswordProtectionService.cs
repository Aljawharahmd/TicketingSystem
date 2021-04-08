using System.Security.Cryptography;
using System.Text;
using Ticketing.Protection.Services.Abstraction;

namespace Ticketing.Protection.Services
{
    public class PasswordProtectionService : IPasswordProtectionService
    {
        public bool VerifyHashedPassword(string plaintText, string hash)
        {
            return hash.Equals(ComputeHash(plaintText));
        }

        public string ComputeHash(string plaintText)
        {
            var stringBuilder = new StringBuilder();

            using var algorithm = SHA256.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plaintText));

            foreach (var b in hash)
                stringBuilder.Append(b.ToString("X2"));

            return stringBuilder.ToString();
        }
    }
}

