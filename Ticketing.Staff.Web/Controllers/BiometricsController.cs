using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Integration.Abstraction;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model.Results;
using Ticketing.Staff.Web.Models;

namespace Ticketing.Staff.Web.Controllers
{
    public class BiometricsController : Controller
    {
        private readonly IAccountProxy _accountProxy;
        private readonly IFileProxy _fileProxy;
        private readonly IBiometricValidator _biometricValidator;

        public BiometricsController(IAccountProxy accountProxy, IFileProxy fileProxy, IBiometricValidator biometricValidator)
        {
            _accountProxy = accountProxy;
            _fileProxy = fileProxy;
            _biometricValidator = biometricValidator;
        }

        [HttpGet]
        public  async Task<IActionResult> Authentication(AuthenticationContext context)
        {
            return View(new BiometricsParameters { Context = context });
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(BiometricsParameters parameters)
        {
            var detected = false;

            if (parameters.Face != null)
            {
                await using var ms = new MemoryStream();
                await parameters.Face.CopyToAsync(ms);
                detected = await _biometricValidator.DetectFace(
                    registered: await _fileProxy.GetFace(parameters.Context.UserId),
                    login: ms.ToArray(),
                    userId: parameters.Context.UserId);
            }

            if (parameters.Voice != null)
            {
                await using var ms = new MemoryStream();
                await parameters.Voice.CopyToAsync(ms);
                detected = await _biometricValidator.DetectVoice(
                    registered: await _fileProxy.GetVoice(parameters.Context.UserId),
                    login: ms.ToArray(),
                    userId: parameters.Context.UserId);
            }


            if (detected)
            {
                var token = await _accountProxy.GenerateToken(parameters.Context);
                if (string.IsNullOrWhiteSpace(token))
                    return RedirectToAction("Login", "Account");

                var options = new CookieOptions { Expires = DateTime.Now.AddMinutes(60) };
                Response.Cookies.Append("Token", token, options);

                switch (parameters.Context.Type)
                {
                    case UserType.Staff:
                        return RedirectToAction("Staff", "Dashboard", new { id = parameters.Context.UserId });
                    case UserType.Manager:
                        return RedirectToAction("Manager", "Dashboard", new { id = parameters.Context.UserId });
                    default:
                        return RedirectToAction("Login", "Account");
                }
            }
            else
                return RedirectToAction("Login", "Account");
        }
    }
}
