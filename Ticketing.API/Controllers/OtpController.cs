using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Protection.Models;
using Ticketing.Protection.Services.Abstraction;

namespace Ticketing.API.Controllers
{
    [Route("api/otp")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> Generate([FromBody]OtpGenerateParameter parameter)
        {
            return Ok(_otpService.Generate(parameter.UserId));
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate([FromQuery] int id)
        {
            return Ok(_otpService.Validate(id));
        }
    }
}
