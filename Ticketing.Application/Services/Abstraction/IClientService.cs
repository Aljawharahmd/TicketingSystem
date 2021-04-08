using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Data.ActionModels.Client.Results;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IClientService
    {
        Task<List<ClientViewResult>> Get();
        Task<ClientViewResult> Get(int id);
        Task<ClientCreateResult> Create(ClientCreateParameters parameters);
        Task<ClientUpdateResult> Update(int id, ClientCreateParameters parameters);
        Task<ClientUpdateResult> Activate(int id);
        Task<ClientUpdateResult> Deactivate(int id);
    }
}