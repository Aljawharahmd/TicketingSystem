using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ticketing.Application.Services.Abstraction;

namespace Ticketing.BackgroundWorker
{
    public class CloseUnUsedTicket : BackgroundService
    {
        private readonly ILogger<CloseUnUsedTicket> _logger;
        private readonly ITicketService _ticketService;

        public CloseUnUsedTicket(ILogger<CloseUnUsedTicket> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var lastTime = DateTime.Now.AddDays(-10);
            while (!stoppingToken.IsCancellationRequested)
            {
                if (!(DateTime.Now.Subtract(lastTime).TotalHours > 24)) continue;


                await _ticketService.CloseUnUsed();
                lastTime = DateTime.Now;
            }
        }
    }
}
