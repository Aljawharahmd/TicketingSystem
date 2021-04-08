using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Security.Authentication.Options;

namespace Ticketing.Security.Authentication.Validation
{
    public class TokenValidator : ITokenValidator
    {
        private readonly ILogger<TokenValidator> _logger;
        private readonly JtwOptions _options;

        public TokenValidator(ILogger<TokenValidator> logger , IOptions<JtwOptions>options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public bool ValidateAndExtract(HttpContext context, string token)
        {
            try
            {
                _logger.LogDebug("TokenValidator, ValidateAndExtract, Parameters token:{token}", token);
                var claims = GetClaims(token);

                if (!claims.Any())
                    return false;

                var user = new TokenUser
                {
                    Token = token,
                    Id = int.Parse(claims.First(x => x.Type == "id").Value),
                    Type = Enum.Parse<UserType>(claims.First(x => x.Type == "type").Value)

                };
                _logger.LogDebug("TokenValidator, ValidateAndExtract, User Id: {id}", user.Id);
                context.Items["User"] = user;
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return false;
            }
        }

        public async Task<bool> ValidateAndExtract(HttpContext context, IUserManagerAuthentication userManagerAuthenticationManager, string token)
        {
            try
            {
                _logger.LogDebug("TokenValidator, ValidateAndExtract, Parameters token:{token}", token);
                var claims = GetClaims(token);

                if (!claims.Any())
                    return false;

                var user = new TokenUser
                {
                    Id = int.Parse(claims.First(x => x.Type == "id").Value),
                    Type = Enum.Parse<UserType>(claims.First(x => x.Type == "type").Value)
                };

                _logger.LogDebug("TokenValidator, ValidateAndExtract, User Id :{user}", user.Id);

                var userContext = await userManagerAuthenticationManager.Get(user.Id, user.Type);

                if (userContext == null)
                {
                    _logger.LogDebug("User not exsits in the databas, user id: {id}", user.Id);
                    return false;
                }

                context.Items["User"] = new TokenUser
                {
                    Id = userContext.UserId,
                    Identifier = userContext.Identifier,
                    Type = userContext.Type,
                };
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return false;
            }
        }

        private IEnumerable<Claim> GetClaims(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return jwtToken.Claims;
        }
    }
}
