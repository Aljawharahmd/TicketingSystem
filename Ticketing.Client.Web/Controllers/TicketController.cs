using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Ticketing.API.Proxies;
using Ticketing.Client.Web.Models;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.Enums;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Models;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Storage;

namespace Ticketing.Client.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IClientProxy _clientProxy;
        private readonly ITicketProxy _ticketProxy;
        private readonly IProductProxy _productProxy;
        private readonly IReplyProxy _replyProxy;
        private readonly StorageOptions _storageOptions;

        public TicketController(IEmailSender emailSender,
            IClientProxy clientProxy,
            ITicketProxy ticketProxy,
            IProductProxy productProxy,
            IReplyProxy replyProxy,
            IOptions<StorageOptions> storageOptions)
        {
            _emailSender = emailSender;
            _clientProxy = clientProxy;
            _ticketProxy = ticketProxy;
            _productProxy = productProxy;
            _replyProxy = replyProxy;
            _storageOptions = storageOptions.Value;
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            var tickets = await _ticketProxy.Get(user.Token, new TicketSearchParameters { ClientId = user.Id });
            var products = await _productProxy.Get(user.Token);

            return View(new TicketCreateViewParameters
            {
                Tickets = tickets,
                ProductViewResult = products,
            });
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var ticketCreateView = new TicketCreateViewParameters
            {
                ProductViewResult = await _productProxy.Get(user.Token),

            };

            return View(ticketCreateView);
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateViewParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            if (parameters.Attachments != null)
            {
                parameters.TicketCreateParameters.Files = new List<StorageCreateParameters>();
                foreach (var attachment in parameters.Attachments)
                {
                    var fileBytes = new byte[] { };
                    if (attachment != null)
                    {
                        await using (var ms = new MemoryStream())
                        {
                            await attachment.CopyToAsync(ms);
                            fileBytes = ms.ToArray();
                        }

                        var fileName = Path.GetFileName(attachment.FileName);
                        parameters.TicketCreateParameters.Files.Add(new StorageCreateParameters
                        {
                            Name = Path.GetFileNameWithoutExtension(fileName),
                            Bytes = fileBytes,
                            Extension = Path.GetExtension(fileName)
                        });
                    }
                }
            }

            var result = await _ticketProxy.Create(user.Token, new TicketCreateParameters
            {
                ClientId = user.Id,
                ProductId = parameters.TicketCreateParameters.ProductId,
                Subject = parameters.TicketCreateParameters.Subject,
                Summary = parameters.TicketCreateParameters.Summary,
                Files = parameters.TicketCreateParameters.Files,

            });

            var client = await _clientProxy.Get(user.Token, user.Id);
            if (result != null)
            {
                _emailSender.Send(new EmailSendParameter
                {
                    ToAddress = client.Email,
                    Subject = $"Your ticket number {result.Id} is received",
                    Body = $"Hello {client.Name}" + "," + $"{Environment.NewLine}"
                           + $"Your Ticket {result.Id} has been successfully submitted" + $"{Environment.NewLine}"
                           + "Find the details of your ticket below:" + $"{Environment.NewLine}"
                           + $"Ticket Number: {result.Id}" + $"{Environment.NewLine}"
                           + $"Date: {result.CreateDateTime}" + $"{Environment.NewLine}"
                           + $"Subject: {result.Subject}" + $"{Environment.NewLine}"
                           + $"Summary: {result.Summary}" + $"{Environment.NewLine}"
                           + "To track your tickets and chat with our support staff, all you need is to LOGIN TO YOUR ACCOUNT and navigate to (My Tickets)." + $"{Environment.NewLine}"
                });
                TempData["message"] = $"Ticket created successfully!." + $"{Environment.NewLine}" +
                $"Your ticket number is: {result.Id}";

                return RedirectToAction("index");
            }
            return View(); // ALERT 
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var ticket = await _ticketProxy.Get(user.Token, id);

            var replies = await _replyProxy.Get(user.Token, new ReplySearchParameters()
            {
                TicketId = id
            });

            ViewBag.userId = user.Id;

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

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPost]
        public async Task<IActionResult> View(TicketRepliesParameters parameters, int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            if (parameters.Attachments != null)
            {
                parameters.Reply.Files = new List<StorageCreateParameters>();
                foreach (var attachment in parameters.Attachments)
                {
                    var fileBytes = new byte[] { };
                    if (attachment != null)
                    {
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
            }
            var result = await _replyProxy.Create(user.Token, new ReplyCreateParameters
            {
                ClientId = parameters.Ticket.ClientId,
                StaffId = parameters.Ticket.StaffMemberId,
                SenderType = SenderType.Client,
                TicketId = id,
                Content = parameters.Reply.Content,
                Files = parameters.Reply?.Files
            });

            if (result == null)
            {
                TempData["errorMessage"] =
                    "There was a problem in sending your reply, please try again!";
                return View();
            }
            _emailSender.Send(new EmailSendParameter
            {
                ToAddress = result.StaffMemberEmail,
                Subject = $"Ticket number {result.Id} has a new reply",
                Body = $"Hello {result.StaffMemberName}" + "," + $"{Environment.NewLine}"
                           + $"Ticket {result.Id}  has a new reply" + $"{Environment.NewLine}"
                           + "Please reply to the client as soon as possible to fix the issues."
            });
            TempData["message"] = "Your reply sent successfully!";

            return RedirectToAction("View", new { id });
        }

        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPost]
        public async Task<IActionResult> CloseTicket(TicketRepliesParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];
            var result = await _ticketProxy.Update(user.Token, parameters.Ticket.Id);
            if (result != null)
            {
                TempData["message"] = $" Your ticket id: {parameters.Ticket.Id } closed successfully";
                return RedirectToAction("Index");
            }
            TempData["errorMessage"] = $"Something went wrong, please try again to close your ticket.";
            return RedirectToAction("View", new { result.Id });
        }
    }
}