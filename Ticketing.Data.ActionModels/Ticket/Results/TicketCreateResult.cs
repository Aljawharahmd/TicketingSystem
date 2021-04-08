using System.Collections.Generic;
using Ticketing.Data.ActionModels.Storage.Result;

namespace Ticketing.Data.ActionModels.Ticket.Results
{
    public class TicketCreateResult : TicketBaseResult
    {
        public List<StorageViewResult> Files { get; set; }
    }
}
