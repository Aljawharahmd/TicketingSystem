using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Model.Results;
using Ticketing.Security.Authentication.Options;

namespace Ticketing.Security.Authentication.Validation
{
    public class JwtMangerAuthentication : IJwtMangerAuthentication
    {
        private readonly JtwOptions _options;
 

        public JwtMangerAuthentication(IOptions<JtwOptions> options)
        {
            _options = options.Value;
        }

        public async Task<string> GenerateToken(AuthenticationContext context)
        {
            var secretKeyBytes = Encoding.ASCII.GetBytes(_options.Secret.ToString());
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
               
                Subject = new ClaimsIdentity(new[] { new Claim("id", context.UserId.ToString()) , new Claim("type", context.Type.ToString()) }),

                Expires = DateTime.Now.AddDays(1),
                IssuedAt = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

