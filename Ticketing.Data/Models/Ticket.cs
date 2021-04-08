using System;
using System.Collections.Generic;
using Ticketing.Data.Enums;

namespace Ticketing.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime CreateDateTime { get; set; }
        public TicketPriority Priority { get; set; }


        public StaffMember Employee { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
        public List<StorageFile> StorageFiles { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
