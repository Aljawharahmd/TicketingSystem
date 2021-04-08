using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Client.Web.Models;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Models;
using Ticketing.Protection.Models;
using Ticketing.Protection.Services.Abstraction;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Security.Authentication.Model.Parameters;

namespace Ticketing.Client.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOtpProxy _otpProxy;
        private readonly ISmsSender _smsSender;
        private readonly IEmailSender _emailSender;
        private readonly IAccountProxy _accountProxy;
        private readonly IClientProxy _clientProxy;
        private readonly IPasswordProtectionService _protectionService;

        public AccountController(IOtpProxy otpProxy,
            ISmsSender smsSender, IEmailSender emailSender,
            IAccountProxy accountProxy, IClientProxy clientProxy,
            IPasswordProtectionService protectionService)
        {
            _otpProxy = otpProxy;
            _smsSender = smsSender;
            _emailSender = emailSender;
            _accountProxy = accountProxy;
            _clientProxy = clientProxy;
            _protectionService = protectionService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var authenticationContext = await _accountProxy.Authenticate(new AuthenticationParameters
            {
                AreaCode = parameters.AreaCode,
                Identifier = parameters.MobileNumber,
                Password = _protectionService.ComputeHash(parameters.Password),
                Type = UserType.Client
            });

            if (authenticationContext != null)
            {
                if (!authenticationContext.RequiredMethods.Any())
                {
                    var token = await _accountProxy.GenerateToken(authenticationContext);
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        TempData["errorMessage"] = "Something went wrong, please try again.";
                        return View();
                    }

                    var options = new CookieOptions { Expires = DateTime.Now.AddMinutes(30) };
                    Response.Cookies.Append("Token", token, options);
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["errorMessage"] = "Your email or password is wrong, please try again";
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            if (Request.Cookies["Token"] != null)
            {
                var options = new CookieOptions { Expires = DateTime.Now.AddDays(-1d) };
                Response.Cookies.Append("Token", "", options);
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ClientUpdateViewParameters parameters)
        {
            var clientCreateParameters = new ClientCreateParameters
            {
                Name = parameters.FirstName + " " + parameters.LastName,
                MobileNumber = parameters.MobileNumber,
                AreaCode = parameters.AreaCode,
                Email = parameters.Email,
                Password = _protectionService.ComputeHash(parameters.Password)
            };
            var client = await _clientProxy.Create(clientCreateParameters);
            if (client != null)
            {

                return RedirectToAction("Otp", new
                {
                    userId = client.Id,
                    mobileNumber = client.AreaCode + client.MobileNumber,
                    email = client.Email
                });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Otp(int userId, string mobileNumber, string email)
        {

            var code = await _otpProxy.Generate(new OtpGenerateParameter
            {
                UserId = userId
            });

            await _smsSender.Send(new SmsSendParameter
            {
                MobileNumber = mobileNumber,
                Text = $"Your Activation code is {code}"
            });
            new OtpParameters
            {
                UserId = userId,
                Email = email
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Otp(OtpParameters otp)
        {
            var code = $"{otp.FirstNumber}" +
                $"{otp.SecondNumber}" +
                $"{otp.ThirdNumber}" +
                $"{otp.FourthNumber}";

            var value = await _otpProxy.Validate(otp.UserId);
            if (!string.IsNullOrWhiteSpace(value) && value.Equals(code))
            {
                var result = await _clientProxy.Activate(otp.UserId);
                if (result != null)
                {
                    _emailSender.Send(new EmailSendParameter
                    {
                        ToAddress = otp.Email,
                        Subject = "Your Account is Now Active",
                        Body = "Hello " + result.Name + ","
                               + Environment.NewLine + "We're glad to inform you that your account is now Active!"
                            + Environment.NewLine + "Now you can submit tickets and our support staff will do their best to resolve your issue."
                    });
                }
                return RedirectToAction("Login");
            }
            return View();
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            var user = (TokenUser)HttpContext.Items["User"];

            var client = await _clientProxy.Get(user.Token, user.Id);
            return View(new ClientUpdateViewParameters
            {
                FirstName = client.Name.Split(" ").First(),
                LastName = client.Name.Split(" ").Last(),
                MobileNumber = client.MobileNumber,
                AreaCode = client.AreaCode,
                Email = client.Email,
            });
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPost]
        public async Task<IActionResult> Profile(ClientUpdateViewParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var clientCreateParameters = new ClientCreateParameters
            {
                Name = parameters.FirstName + " " + parameters.LastName,
                MobileNumber = parameters.MobileNumber,
                AreaCode = parameters.AreaCode,
                Email = parameters.Email,
                Password = _protectionService.ComputeHash(parameters.Password)
            };
            await _clientProxy.Update(user.Token, user.Id, clientCreateParameters);
            return RedirectToAction("Profile");
        }
    }
}
