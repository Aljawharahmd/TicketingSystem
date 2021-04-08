using System.Collections.Generic;
using Ticketing.Data.ActionModels.Product.Results;
using Ticketing.Data.ActionModels.StaffMember.Results;
using Ticketing.Data.ActionModels.Ticket.Results;
using Ticketing.Data.Enums;

namespace Ticketing.Staff.Web.Models
{
    public class ListOfTicketsParameters
    {
        public List<TicketViewResult> Tickets { get; set; }
        public List<StaffMemberViewResult> Staff { get; set; }
        public int StaffId { get; set; }
        public int TicketId { get; set; }
        public List<ProductViewResult> Products { get; set; }
    }
}
