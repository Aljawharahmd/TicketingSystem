using System;
using System.Collections.Generic;
using Ticketing.Data.ActionModels.Storage.Result;

namespace Ticketing.Data.ActionModels.Reply.Results
{
   public class ReplyBaseResult
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Content { get; set; }
        public List<StorageViewResult> Files { get; set; }
        public int? TicketId { get; set; }
        public string ClientName { get; set; }
        public string StaffMemberName { get; set; }
        public string StaffMemberEmail { get; set; }


    }
}
