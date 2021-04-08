using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Statistic.Results;

namespace Ticketing.API.Proxies
{
    public interface IStatisticProxy
    {
        [Get("/api/statistic/GetOpenTicket")]
        public Task<int> GetOpenTicket([Header("Authorization")] string authorization);

        [Get("/api/statistic/GetCloseTicket")]
        public Task<int> GetCloseTicket([Header("Authorization")] string authorization);

        [Get("/api/statistic/GetCloseTicket/{staffMemberId}")]
        public Task<int> GetCloseTicket([Header("Authorization")] string authorization,int staffMemberId);

        [Get("/api/statistic/GetInprogressTicket/{staffMemberId}")]
        public Task<int> GetInprogressTicket([Header("Authorization")] string authorization,int staffMemberId);

        [Get("/api/statistic/GetSolveTicket/{staffMemberId}")]
        public Task<int> GetSolveTicket([Header("Authorization")] string authorization , int staffMemberId);

        [Get("/api/statistic/GetAllClients")]
        public Task<int> GetAllClients([Header("Authorization")] string authorization);

        [Get("/api/statistic/MostProductive")]
        public Task<MostProductiveEmployeeResult> MostProductiveEmployee([Header("Authorization")] string authorization);

        [Get("/api/statistic/AverageTicketsPerStaff")]
        public Task<int> AverageTicketsPerStaff([Header("Authorization")] string authorization);

        [Get("/api/statistic/NumberOfTicketsPerProduct")]
        public Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct([Header("Authorization")] string authorization);

        [Get("/api/statistic/NumberOfTicketsPerProduct/{staffMemberId}")]
        public Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct([Header("Authorization")] string authorization,int staffMemberId);

        [Get("/api/statistic/NumberOfTicketsStatus")]
        public Task<List<TicketPerStatusResult>> NumberOfTicketsStatus([Header("Authorization")] string authorization);

        [Get("/api/statistic/NumberOfTicketsPerEmployee")]
        public Task<List<TicketsPerStaffResult>> NumberOfTicketsPerEmployee([Header("Authorization")] string authorization);

    }
}
