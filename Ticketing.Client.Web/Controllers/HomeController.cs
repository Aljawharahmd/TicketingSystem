using Microsoft.AspNetCore.Mvc;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.Client.Web.Controllers
{

    public class HomeController : Controller
    {

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
