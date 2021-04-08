using Microsoft.AspNetCore.Mvc;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;

namespace Ticketing.Staff.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet]
        public IActionResult Index()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            if (user != null)
            {
                if (user.Type == UserType.Manager)
                    return RedirectToAction("Manager", "Dashboard", new { id = user.Id });
                if (user.Type == UserType.Staff)
                    return RedirectToAction("Staff", "Dashboard");
            }
            return RedirectToAction("Login", "Account");

        }
    }
}
