using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Data.ActionModels.Reply.Parameters
{
   public class ReplyBaseParameters
    {
        public int? ClientId { get; set; }
        public int? StaffId { get; set; }
        public int? TicketId { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
