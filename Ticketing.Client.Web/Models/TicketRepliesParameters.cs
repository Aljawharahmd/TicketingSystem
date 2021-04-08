using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.ActionModels.Ticket.Results;

namespace Ticketing.Client.Web.Models
{
    public class TicketRepliesParameters
    {
        public TicketViewResult Ticket { get; set; }
        public List<ReplyViewResult> Replies { get; set; }
        public ReplyCreateParameters Reply { get; set; }
        public List<IFormFile> Attachments { get; set; }

    }
}
