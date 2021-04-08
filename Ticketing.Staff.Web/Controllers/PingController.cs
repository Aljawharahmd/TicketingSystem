using Microsoft.AspNetCore.Mvc;

namespace Ticketing.Staff.Web.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : Controller
    {
        public IActionResult Get()
        {
            return Ok("TickIt Staff Web is Working!!");
        }
    }
}
