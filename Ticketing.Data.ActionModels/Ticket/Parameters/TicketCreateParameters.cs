using System.Collections.Generic;
using Ticketing.Data.ActionModels.Storage.Parameters;

namespace Ticketing.Data.ActionModels.Ticket.Parameters
{
    public class TicketCreateParameters 
    {
        public string Subject { get; set; }
        public string Summary { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public List<StorageCreateParameters> Files { get; set; }
    }
}