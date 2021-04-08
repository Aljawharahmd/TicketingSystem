using System;

namespace Ticketing.Data.ActionModels.Ticket.Results
{
    public class TicketUpdateResult : TicketBaseResult
    {
        public DateTime? CloseDate { get; set; }
    }
}
