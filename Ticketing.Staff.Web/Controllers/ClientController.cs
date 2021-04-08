using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;

namespace Ticketing.Staff.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientProxy _clientProxy;
        
        public ClientController(IClientProxy clientProxy)
        {
            _clientProxy = clientProxy;
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            var clients = await _clientProxy.Get(user.Token);
            return View(clients);
        }

        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Activate([FromRoute]int id)
        {
            await _clientProxy.Activate(id);
            return RedirectToAction("List");
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Deactivate([FromRoute]int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            await _clientProxy.Deactivate(user.Token,id);
            return RedirectToAction("List");
        }
    }
}
