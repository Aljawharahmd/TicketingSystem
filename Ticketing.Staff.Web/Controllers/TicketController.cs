using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Ticketing.API.Proxies;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.Enums;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Staff.Web.Models;
using Ticketing.Storage;

namespace Ticketing.Staff.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketProxy _ticketProxy;
        private readonly IReplyProxy _replyProxy;
        private readonly IStaffMemberProxy _staffProxy;
        private readonly IProductProxy _productProxy;
        private readonly StorageOptions _storageOptions;

        public TicketController(ITicketProxy ticketProxy,
                                IReplyProxy replyProxy,
                                IStaffMemberProxy staffProxy,
                                IProductProxy productProxy,
                                IOptions<StorageOptions> storageOptions )
        {
            _ticketProxy = ticketProxy;
            _replyProxy = replyProxy;
            _staffProxy = staffProxy;
            _productProxy = productProxy;
            _storageOptions = storageOptions.Value;

        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet]
        public async Task<IActionResult> ManagerView(int id)
        {
            var ticket = await _ticketProxy.Get(id);

            foreach (var item in ticket.Files)
            {
                item.DonwloadPath = $"{_storageOptions.DownloadPath}/{item.Id}";
            }

            return View(new TicketRepliesParameters
            {
                Ticket = ticket,
             });
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var tickets = await _ticketProxy.Get();
            var staff = await _staffProxy.Get(user.Token);
            var products = await _productProxy.Get();
            return View(new ListOfTicketsParameters
            {
                Tickets = tickets,
                Staff = staff,
                Products = products,
            });
        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPost]
        public async Task<JsonResult> SaveChanges(TicketChangeInformationParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            await _ticketProxy.Update(user.Token,parameters);
            TempData["message"] = $" Your change is save successfully ";

            return Json(new { });
        }


        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet]
        public async Task<IActionResult> StaffView(int id)
        {
            var ticket = await _ticketProxy.Get(id);

            var replies = await _replyProxy.Get(new ReplySearchParameters()
            {
                TicketId = id
            });
            foreach (var item in ticket.Files)
            {
                item.DonwloadPath = $"{_storageOptions.DownloadPath}/{item.Id}";
            }
            foreach (var reply in replies)
            {
                foreach (var item in reply.Files)
                {
                    item.DonwloadPath = $"{_storageOptions.DownloadPath}/{item.Id}";
                }
            }


            return View(new TicketRepliesParameters
            {
                Ticket = ticket,
                Replies = replies
            });
        }
        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpPost]
        public async Task<IActionResult> StaffView(TicketRepliesParameters parameters, int id)
        {
            if (parameters.Attachments != null )
            {
                parameters.Reply.Files = new List<StorageCreateParameters>();
                foreach (var attachment in parameters.Attachments)
                {
                    byte[] fileBytes;
                    if (attachment == null) continue;

                    await using (var ms = new MemoryStream())
                    {
                        await attachment.CopyToAsync(ms);
                        fileBytes = ms.ToArray();

                    }
                    var fileName = Path.GetFileName(attachment.FileName);
                    parameters.Reply.Files.Add(new StorageCreateParameters
                    {
                        Name = Path.GetFileNameWithoutExtension(fileName),
                        Bytes = fileBytes,
                        Extension = Path.GetExtension(fileName)

                    });

                }
            }
            await _replyProxy.Create(new ReplyCreateParameters
            {
                ClientId = parameters.Ticket.ClientId,
                StaffId = parameters.Ticket.StaffMemberId,
                SenderType = SenderType.StaffMember,
                TicketId = id,
                Content = parameters.Reply.Content,
                Files = parameters.Reply.Files
            });
            TempData["message"] = $" Your reply is sent successfully ";

            return RedirectToAction("StaffView", new { id});
        }

        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet]
        public async Task<IActionResult> ListAssigned()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            var tickets = await _ticketProxy.Get(new TicketSearchParameters { EmployeeId = user.Id });
            return View(tickets);
        }

    }
}
