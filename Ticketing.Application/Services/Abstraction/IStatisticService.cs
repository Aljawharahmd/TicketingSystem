using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Statistic.Results;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IStatisticService
    {
        Task<int> GetInprogressTicket();
        Task<int> GetOpenTicket();
        Task<int> GetCloseTicket();
        Task<int> GetAllClients();
        Task<int> GetInprogressTicket(int staffMemberId);
        Task<int> GetSolveTicket(int staffMemberId);
        Task<int> GetCloseTicket(int staffMemberId);
        Task<MostProductiveEmployeeResult> MostProductiveEmployee();
        Task<int> AverageTicketsPerStaff();
        Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct();
        Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct(int staffMemberId);
        Task<List<TicketPerStatusResult>> NumberOfTicketsStatus();
        Task<List<TicketsPerStaffResult>> NumberOfTicketsPerEmployee();
    }
}
