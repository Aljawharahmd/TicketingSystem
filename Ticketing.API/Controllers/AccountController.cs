using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Model.Parameters;
using Ticketing.Security.Authentication.Model.Results;

namespace Ticketing.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManagerAuthentication _userManagerAuthentication;
        private readonly IJwtMangerAuthentication _jwtMangerAuthentication;

        public AccountController(IUserManagerAuthentication userManagerAuthentication, IJwtMangerAuthentication jwtMangerAuthentication)
        {
            _userManagerAuthentication = userManagerAuthentication;
            _jwtMangerAuthentication = jwtMangerAuthentication;

        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationParameters parameters)
        {
            var context = await _userManagerAuthentication.Get(parameters);
            if (context == null)
            {
                return Ok(new AuthenticationContext());
            }

            return Ok(context);
        }

        [AllowAnonymous]
        [HttpPost("generateToken")]
        public async Task<IActionResult> GenerateToken([FromBody]AuthenticationContext context)
        {
          var token = await _jwtMangerAuthentication.GenerateToken(context);
            if (token == null)
                return Unauthorized();

            return Ok(token);
         }
    }
}
