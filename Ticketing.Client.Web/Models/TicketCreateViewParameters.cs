using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Ticketing.Data.ActionModels.Product.Results;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.ActionModels.Ticket.Results;

namespace Ticketing.Client.Web.Models
{
    public class TicketCreateViewParameters
    {
        public TicketCreateParameters TicketCreateParameters { get; set; }
        public List< ProductViewResult> ProductViewResult { get; set; }
        public ProductViewResult Product { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public List<TicketViewResult> Tickets { get; set; }


    }
}
