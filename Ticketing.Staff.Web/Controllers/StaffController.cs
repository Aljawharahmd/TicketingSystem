using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;

namespace Ticketing.Staff.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffMemberProxy _staffProxy;

        public StaffController(IStaffMemberProxy staffProxy)
        {
            _staffProxy = staffProxy;
        }
        public async Task<IActionResult> List()
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var staff = await _staffProxy.Get(user.Token);
            return View(staff);
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Activate([FromRoute] int id)
        {
            await _staffProxy.Activate(id);
            return RedirectToAction("List");
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Deactivate([FromRoute] int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];
            await _staffProxy.Deactivate(user.Token,id);
            return RedirectToAction("List");
        }
    }
}
