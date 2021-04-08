using System.Collections.Generic;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.ActionModels.Ticket.Results;

namespace Ticketing.Data.ActionModels.Client.Results
{
    public class ClientViewResult : ClientBaseResult
    {
        public int NumberOfTickets { get; set; }
        public List<TicketViewResult> Tickets { get; set; }
        public List<ReplyViewResult> Replies { get; set; }
    }
}
