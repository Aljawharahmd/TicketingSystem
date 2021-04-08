using System;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Ticket.Results
{
    public abstract class TicketBaseResult
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public TicketPriority Priority { get; set; }
        public string StaffMemberName { get; set; }
        public string ProductName { get; set; }
        public string ClientName { get; set; }
    }
}
