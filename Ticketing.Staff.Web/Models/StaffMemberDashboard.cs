using System.Collections.Generic;
using Ticketing.Data.ActionModels.Statistic.Results;

namespace Ticketing.Staff.Web.Models
{
    public class StaffMemberDashboard
    {
        public int StaffId  { get; set; }
        public int SolvedTickets { get; set; }
        public int ClosedTickets { get; set; }
        public int InprogressTicket { get; set; }
        public List<TicketsPerProductResult> NumberOfTicketsPerProduct { get; set; }
    }
}
