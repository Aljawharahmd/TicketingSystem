using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.ActionModels.Ticket.Results;
using Ticketing.Data.Enums;

namespace Ticketing.Application.Services.Abstraction
{
    public interface ITicketService
    {
        Task<List<TicketViewResult>> Get();
        Task<TicketViewResult> Get(int id);
        Task<List<TicketViewResult>> Get(TicketSearchParameters parameters);
        Task<TicketCreateResult> Create(TicketCreateParameters parameters);
        Task<TicketUpdateResult> Update(int id);
        Task<TicketUpdateResult> Update(int id, int assignedTo, TicketPriority priority);
        Task CloseUnUsed();
    }
}
