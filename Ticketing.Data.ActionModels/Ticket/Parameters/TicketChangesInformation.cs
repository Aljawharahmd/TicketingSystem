using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Ticket.Parameters
{
    public class TicketChangesInformation
    {

        public int Id { get; set; }
        public int AssignedTo { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
