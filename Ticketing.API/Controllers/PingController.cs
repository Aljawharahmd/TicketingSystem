using Microsoft.AspNetCore.Mvc;

namespace Ticketing.API.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("TickIt Api is Working!!");
        }
    }
}