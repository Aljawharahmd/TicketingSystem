using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.ActionModels.Ticket.Results;

namespace Ticketing.API.Proxies
{
    public interface ITicketProxy
    {

        [Get("/api/ticket/Get")]
        Task<List<TicketViewResult>> Get([Header("Authorization")] string authorization);

        [Get("/api/ticket/search")]
        Task<List<TicketViewResult>> Get([Header("Authorization")] string authorization, TicketSearchParameters parameters);

        [Get("/api/ticket/{id}")]
        Task<TicketViewResult> Get([Header("Authorization")] string authorization, int id);

        [Post("/api/ticket/create")]
        Task<TicketCreateResult> Create([Header("Authorization")] string authorization, TicketCreateParameters parameters);

        [Put("/api/ticket/update")]
        Task<TicketUpdateResult> Update([Header("Authorization")] string authorization, int id);

        [Put("/api/ticket/updateList")]
        Task<TicketUpdateResult> Update([Header("Authorization")] string authorization, TicketChangeInformationParameters parameter);
    }
}
