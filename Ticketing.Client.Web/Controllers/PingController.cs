using Microsoft.AspNetCore.Mvc;

namespace Ticketing.Client.Web.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : Controller
    {
        public IActionResult Get()
        {
            return Ok("TickIt Client Web is Working!!");
        }
    }
}
