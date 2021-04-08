using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Client.Web.Models;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;

namespace Ticketing.Client.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProxy _fileProxy;

        public FileController(IFileProxy fileProxy)
        {
            _fileProxy = fileProxy;
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var temp = await _fileProxy.Get(user.Token, id);
            var file = new FileParameters { Image = Convert.ToBase64String(temp) };
            return View(file);
        }
    }
}
