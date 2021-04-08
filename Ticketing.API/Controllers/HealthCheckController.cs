using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.Enums;

namespace Ticketing.API.Controllers
{
    [Route("api/HealthCheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IReplyService _replyService;

        public HealthCheckController(ITicketService ticketService, IReplyService replyService)
        {
            _ticketService = ticketService;
            _replyService = replyService;
        }

        [Route("ticket")]
        public async Task<HealthCheckResult> CreateTicketHealthCheck()
        {
            var result = await _ticketService.Create(new TicketCreateParameters
            {
                Subject = "Healthy subject",
                Summary = "I have a problem with this program (for health checks)",
                ProductId = 1,
                ClientId = 1,
            });
            if (result == null)
            {
                return HealthCheckResult.Unhealthy("Unhealthy, process doesn't work successfully!");
            }
            return HealthCheckResult.Healthy("Health, process work successfully!");
        }

        [Route("reply")]
        public async Task<HealthCheckResult> CreateReplyHealthCheck()
        {
            var result = await _replyService.Create(new ReplyCreateParameters
            {
                SenderType = SenderType.Client,
                CreateDateTime = DateTime.Now.Date,
                Content = "This program cannot work fast as expected (for health checks)",
                ClientId = 1,
                StaffId = 1,
                TicketId = 1
            });
            if (result == null)
            {
                return HealthCheckResult.Unhealthy("Unhealthy, process doesn't work successfully !!");
            }
            return HealthCheckResult.Healthy("Health, process work successfully !!");
        }
    }
}
