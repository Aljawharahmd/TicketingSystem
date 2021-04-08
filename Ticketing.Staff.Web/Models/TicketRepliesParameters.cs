using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.ActionModels.Ticket.Results;

namespace Ticketing.Staff.Web.Models
{
    public class TicketRepliesParameters
    {
        public TicketViewResult Ticket { get; set; }
        public List<ReplyViewResult> Replies { get; set; }
        public ReplyCreateParameters Reply { get; set; }
        public List<IFormFile> Attachments { get; set; }



    }
}
