using System.Collections.Generic;
using Ticketing.Data.ActionModels.Statistic.Results;

namespace Ticketing.Staff.Web.Models
{
    public class ManagerDashboard
    {
        public int OpenTickets { get; set; }
        public int ClosedTickets { get; set; }
        public int AllClients { get; set; }
        public int AverageTicketsPerStaff { get; set; }
        public MostProductiveEmployeeResult MostProductiveEmployee { get; set; }
        public List<TicketsPerProductResult> NumberOfTicketsPerProduct { get; set; }
        public List<TicketPerStatusResult> NumberOfTicketsStatus { get; set; }
        public List<TicketsPerStaffResult> NumberOfTicketsPerStaff { get; set; }

    }
}
