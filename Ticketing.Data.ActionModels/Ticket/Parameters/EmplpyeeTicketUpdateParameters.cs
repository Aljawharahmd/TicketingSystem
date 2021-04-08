using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Ticket.Parameters
{
    public class EmplpyeeTicketUpdateParameters : TicketBaseParameters
    {
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
        public DateTime CloseDate { get; set; }


    }
}
