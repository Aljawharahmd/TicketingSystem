using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Ticket.Parameters
{
    public class TicketSearchParameters  : TicketBaseParameters
    {
        public int? Id { get; set; }
        public TicketStatus? Status { get; set; }
        public int? ProductId { get; set; }
        public int? ClientId { get; set; }
        
    }
}
