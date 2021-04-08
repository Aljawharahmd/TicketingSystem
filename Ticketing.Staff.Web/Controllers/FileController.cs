using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Staff.Web.Models;

namespace Ticketing.Staff.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProxy _fileProxy;

        public FileController(IFileProxy fileProxy)
        {
            _fileProxy = fileProxy;
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var temp = await _fileProxy.Get(id);
            var file = new FileParameters { Image = Convert.ToBase64String(temp) };
            return View(file);

        }
    }
}
