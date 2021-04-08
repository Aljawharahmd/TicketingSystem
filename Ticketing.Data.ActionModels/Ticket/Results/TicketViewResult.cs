using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Storage.Result;

namespace Ticketing.Data.ActionModels.Ticket.Results
{
    public class TicketViewResult : TicketBaseResult
    {
        public int ClientId { get; set; }
        public int? StaffMemberId { get; set; }
        public string ClientEmail { get; set; }
        public List<StorageViewResult> Files { get; set; }
        public Task<DateTime?> LastModifiedDateTime { get; set; }

    }
}
