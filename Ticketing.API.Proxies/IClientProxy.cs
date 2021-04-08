using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Data.ActionModels.Client.Results;

namespace Ticketing.API.Proxies
{
    public interface IClientProxy
    {
        [Get("/api/clients/Get")]
        Task<List<ClientViewResult>> Get([Header("Authorization")] string authorization);
     
        [Get("/api/clients/GetById")]
        Task<ClientViewResult> Get([Header("Authorization")] string authorization, int id);

        [Post("/api/clients/create")]
        Task<ClientCreateResult> Create(ClientCreateParameters parameters);

        [Put("/api/clients/update")]
        Task<ClientCreateResult> Update([Header("Authorization")]string authorization, int id, ClientCreateParameters parameters);

        [Put("/api/clients/activate")]
        Task<ClientUpdateResult> Activate(int id);

        [Put("/api/clients/deactivate/{id}")]
        Task<ClientUpdateResult> Deactivate([Header("Authorization")] string authorization, int id);
    }
}
