using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Storage.Result;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.ActionModels.Ticket.Results;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Storage.Abstractions;

namespace Ticketing.API.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IPathGenerator _pathGenerator;
        private readonly IFileStorage _fileStorage;
        private readonly IStorageService _storageService;
        public TicketController(
            ITicketService ticketService,
            IPathGenerator pathGenerator,
            IFileStorage fileStorage,
            IStorageService storageService)
        {
            _ticketService = ticketService;
            _pathGenerator = pathGenerator;
            _fileStorage = fileStorage;
            _storageService = storageService;
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string authorization)
        {
            var tickets = await _ticketService.Get();
            if (tickets == null || !tickets.Any())
                return Ok(new List<TicketViewResult>());

            return Ok(tickets);
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff, UserType.Client })]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string authorization, [FromRoute] int id)
        {
            var ticket = await _ticketService.Get(id);
            if (ticket == null)
                return Ok(new List<TicketViewResult>());

            ticket.Files = new List<StorageViewResult>();
            var filesInformation = await _storageService.Get(ticket.Id);
            if (filesInformation != null)
            {
                foreach (var item in filesInformation)
                {
                    ticket.Files.Add(new StorageViewResult
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Extension = item.Extension,
                    });
                }
            }
            return Ok(ticket);
        }

        [Authorize(Rules = new[] { UserType.Staff, UserType.Client })]
        [HttpGet("search")]
        public async Task<IActionResult> Get(string authorization, [FromQuery] TicketSearchParameters parameters)
        {
            var tickets = await _ticketService.Get(parameters);
            if (tickets == null || !tickets.Any())
                return Ok(new List<TicketViewResult>());

            foreach (var ticket in tickets)
            {
                ticket.Files = new List<StorageViewResult>();
                var filesInformation = await _storageService.Get(new StorageSearchParameters { TicketId = ticket.Id });
                if (filesInformation != null)
                {
                    foreach (var item in filesInformation)
                    {
                        ticket.Files.Add(new StorageViewResult
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Extension = item.Extension,
                        });
                    }
                }
            }
            return Ok(tickets);
        }
        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPost("create")]
        public async Task<ActionResult> Post(string authorization, [FromBody]TicketCreateParameters parameter)
        {
            var ticket = await _ticketService.Create(parameter);

            if (ticket == null)
                return Ok(new TicketCreateResult());

            if (parameter.Files != null)
            {
                ticket.Files = new List<StorageViewResult>();
                foreach (var item in parameter.Files)
                {
                    item.TicketId = ticket.Id;
                    var file = await _storageService.Create(item);
                    var path = _pathGenerator.Generate(file.Id);
                    await _fileStorage.Save(path, item.Bytes);
                    ticket.Files.Add(file);
                }
            }
            return Ok(ticket);
        }
        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPut("update")]
        public async Task<ActionResult> Put(string authorization, int id)
        {
            var result = await _ticketService.Update(id);
            if (result == null)
                return Ok(new TicketUpdateResult());

            return Ok(result);
        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPut("updateList")]
        public async Task<ActionResult> Put(string authorization, TicketChangeInformationParameters parameters)
        {
            if (parameters != null)
            {
                foreach (var ticket in parameters.Changes)
                {
                    await _ticketService.Update(ticket.Id, ticket.AssignedTo, ticket.Priority);
                }
            }
            else
            {
                return Ok(new TicketChangeInformationParameters());
            }
            return Ok();
        }
    }
}
