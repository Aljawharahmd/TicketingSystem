using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Data.ActionModels.Files.Parameters;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Models;
using Ticketing.Protection.Models;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Security.Authentication.Model.Parameters;
using Ticketing.Staff.Web.Models;
using Ticketing.Storage.Enum;

namespace Ticketing.Staff.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IFileProxy _fileProxy;
        private readonly IOtpProxy _otpProxy;
        private readonly ISmsSender _smsSender;
        private readonly IStaffMemberProxy _staffProxy;
        private readonly IEmailSender _emailSender;
        private readonly IAccountProxy _accountProxy;

        public AccountController(IFileProxy fileProxy, IOtpProxy otpProxy, ISmsSender smsSender, IStaffMemberProxy staffProxy, IEmailSender emailSender, IAccountProxy accountProxy)
        {
            _fileProxy = fileProxy;
            _otpProxy = otpProxy;
            _smsSender = smsSender;
            _staffProxy = staffProxy;
            _emailSender = emailSender;
            _accountProxy = accountProxy;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters loginParameters)
        {
            var authenticationContext = await _accountProxy.Authenticate(new AuthenticationParameters
            {
                Identifier = loginParameters.MobileNumber,
                AreaCode = loginParameters.AreaCode ,
                Type = UserType.Staff
            });

            if (authenticationContext != null)
                return RedirectToAction("Authentication", "Biometrics", authenticationContext );
            return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            if (Request.Cookies["Token"] != null)
            {
                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1d);
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
        public async Task<IActionResult> Register(StaffMemberUpdateViewParameters parameters)
        {
            var staffCreateParameters = new StaffMemberCreateParameters
            {
                Name = parameters.FirstName + " " + parameters.LastName,
                MobileNumber = parameters.MobileNumber,
                AreaCode = parameters.AreaCode,
                Email = parameters.Email,
                Address = parameters.Address,
                BirthDate = parameters.BirthDate,
            };


            var staffMember = await _staffProxy.Create(staffCreateParameters);
            _emailSender.Send(new EmailSendParameter
            {
                ToAddress = parameters.Email,
                Subject = "TickIT Registration",
                Body = "Hello!"//need user name 
            });
            return RedirectToAction("Otp", new
            {
                userId = staffMember.Id,
                mobileNumber = staffMember.MobileNumber,
                email = staffMember.Email
            });

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
                Text = $"Your activation key is {Environment.NewLine}{code}"
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
                return RedirectToAction("RegistrationAttachments", new
                {
                    userId = otp.UserId,
                    email = otp.Email
                });

            return View();
        }
        [HttpGet]
        public IActionResult RegistrationAttachments(int userId, string email)
        {
            return View(new RegistrationParameters { StaffId = userId, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationAttachments(RegistrationParameters parameters)
        {
            if (parameters.Face != null || parameters.Voice != null)
            {
                if (parameters.Face != null)
                {
                    byte[] imageBytes;
                    await using (var ms = new MemoryStream())
                    {
                        await parameters.Face.CopyToAsync(ms);
                        imageBytes = ms.ToArray();

                    }
                    await _fileProxy.Upload(new FileUploadParameters
                    {
                        Bytes = imageBytes,
                        StaffId = parameters.StaffId,
                        Type = FileType.Face
                    });
                }
                if (parameters.Voice != null)
                {
                    byte[] voiceBytes;
                    await using (var ms = new MemoryStream())
                    {
                        await parameters.Voice.CopyToAsync(ms);
                        voiceBytes = ms.ToArray();
                    }
                    await _fileProxy.Upload(new FileUploadParameters
                    {
                        Bytes = voiceBytes,
                        StaffId = parameters.StaffId,
                        Type = FileType.Voice
                    });
                }

                var result = await _staffProxy.Activate(parameters.StaffId);
                if (result != null)
                {
                    _emailSender.Send(new EmailSendParameter
                    {
                        ToAddress = parameters.Email,
                        Subject = "TickIT Registration",
                        Body = "Hello!"//need user name 
                    });
                }
                return RedirectToAction("Login");


            }
            return View();
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            if (user != null && user.Type.ToString()== "Staff")
               TempData["Staff"] = "Staff";

            var staffMember = await _staffProxy.Get(user.Token, user.Id);
            return View(new StaffMemberUpdateViewParameters
            {
                FirstName = staffMember.Name.Split(" ").First(),
                LastName = staffMember.Name.Split(" ").Last(),
                MobileNumber = staffMember.MobileNumber,
                AreaCode = staffMember.AreaCode,
                Email = staffMember.Email,
                Address = staffMember.Address,
                BirthDate = staffMember.BirthDate,
                UserId = staffMember.Id

            });
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpPost]
        public async Task<IActionResult> Profile(StaffMemberUpdateViewParameters parameters)
        {
            var staffMember = new StaffMemberCreateParameters
            {
                Name = parameters.FirstName + " " + parameters.LastName,
                MobileNumber = parameters.AreaCode + parameters.MobileNumber,
                Email = parameters.Email,
                Address = parameters.Address,
                BirthDate = parameters.BirthDate
            };
            await _staffProxy.Update(parameters.UserId, staffMember);
            TempData["message"] = $" Your change is save successfully ";

            return RedirectToAction("Profile");

        }
    }
}
