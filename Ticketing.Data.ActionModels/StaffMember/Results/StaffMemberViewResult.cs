using System;
using System.Collections.Generic;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.ActionModels.Storage.Result;
using Ticketing.Data.ActionModels.Ticket.Results;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.StaffMember.Results
{
    public class StaffMemberViewResult : StaffMemberBaseResult
    {
        public StaffMemberRole Role { get; set; }
        public List<StorageViewResult> Files { get; set; }
        public List<TicketViewResult> Tickets { get; set; }
        public List<ReplyViewResult> Replies { get; set; }

    }
}
