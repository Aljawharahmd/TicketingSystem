using System.Collections.Generic;
using Ticketing.Data.Enums;

namespace Ticketing.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
