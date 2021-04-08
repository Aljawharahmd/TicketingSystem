using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Staff.Web.Models;

namespace Ticketing.Staff.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStatisticProxy _statisticProxy;
        public DashboardController(IStatisticProxy statisticProxy)
        {
            _statisticProxy = statisticProxy;
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            var user = (TokenUser)HttpContext.Items["User"];
            var openTickets = await _statisticProxy.GetOpenTicket(user.Token);
            var closedTickets = await _statisticProxy.GetCloseTicket(user.Token);
            var allClients = await _statisticProxy.GetAllClients(user.Token);
            var mostProductiveStaffMember = await _statisticProxy.MostProductiveEmployee(user.Token);
            var averageTicketsPerStaff = await _statisticProxy.AverageTicketsPerStaff(user.Token);
            var numberOfTicketsPerProduct = await _statisticProxy.NumberOfTicketsPerProduct(user.Token);
            var numberOfTicketsStatus = await _statisticProxy.NumberOfTicketsStatus(user.Token);
            var numberOfTicketsPerStaff = await _statisticProxy.NumberOfTicketsPerEmployee(user.Token);

            return View(new ManagerDashboard
            {
                OpenTickets = openTickets,
                ClosedTickets = closedTickets,
                AllClients = allClients,
                MostProductiveEmployee = mostProductiveStaffMember,
                AverageTicketsPerStaff = averageTicketsPerStaff,
                NumberOfTicketsPerProduct = numberOfTicketsPerProduct,
                NumberOfTicketsStatus = numberOfTicketsStatus,
                NumberOfTicketsPerStaff = numberOfTicketsPerStaff,
            });
        }

        [Authorize(UserType = UserType.Staff)]
        [HttpGet]
        public async Task<IActionResult> Staff()
        {
            var user = (TokenUser)HttpContext.Items["User"];

            var closedTickets = await _statisticProxy.GetCloseTicket(user.Token,user.Id);
            var solvedTickets = await _statisticProxy.GetSolveTicket(user.Token,user.Id);
            var inProgressTickets = await _statisticProxy.GetInprogressTicket(user.Token,user.Id);
            var numberOfTicketsPerProduct = await _statisticProxy.NumberOfTicketsPerProduct(user.Token,user.Id);

            return View(new StaffMemberDashboard
            {
                ClosedTickets = closedTickets,
                SolvedTickets = solvedTickets,
                InprogressTicket = inProgressTickets,
                NumberOfTicketsPerProduct = numberOfTicketsPerProduct,
            });
        }
    }
}
