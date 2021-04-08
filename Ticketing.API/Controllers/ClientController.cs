using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Data.ActionModels.Client.Results;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string authorization)
        {
            var clients = await _clientService.Get();
            if (clients == null)
            {
                return Ok(new List<ClientViewResult>());
            }
            return Ok(clients);
        }
        [Authorize(Rules = new[] { UserType.Client })]
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(string authorization, int id)
        {
            var client = await _clientService.Get(id);
            return Ok(client ?? null);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post(ClientCreateParameters parameters)
        {
            var client = await _clientService.Create(parameters);
            if (client == null)
            {
                return Ok(new ClientCreateResult());
            }
            return Ok(client);
        }
        [Authorize(Rules = new[] { UserType.Client })]
        [HttpPut("update")]
        public async Task<IActionResult> Put(string authorization, int id, ClientCreateParameters parameters)
        {
            var client = await _clientService.Update(id, parameters);
            if (client == null)
            {
                return Ok(new ClientCreateResult());
            }
            return Ok(client);
        }
        [HttpPut("activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var client = await _clientService.Activate(id);
            if (client == null)
            {
                return Ok(new ClientUpdateResult());
            }
            return Ok(client);
        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate([FromRoute] string authorization, int id)
        {
            var client = await _clientService.Deactivate(id);
            if (client == null)
            {
                return Ok(new ClientUpdateResult());
            }
            return Ok(client);
        }
    }
}
