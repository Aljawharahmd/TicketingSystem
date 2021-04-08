using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Data.ActionModels.StaffMember.Results;

namespace Ticketing.API.Proxies
{
    public interface IStaffMemberProxy
    {
        [Get("/api/staffMember/Get")]
        Task<List<StaffMemberViewResult>> Get([Header("Authorization")] string authorization);

        [Get("/api/staffMember/getById")]
        Task<StaffMemberViewResult> Get([Header("Authorization")] string authorization, int id);

        [Post("/api/staffMember/create")]
        Task<StaffMemberCreateResult> Create(StaffMemberCreateParameters parameters);

        [Put("/api/staffMember/update")]
        Task<StaffMemberUpdateResult> Update([Header("Authorization")] string authorization, int id, StaffMemberCreateParameters parameters);

        [Put("/api/staffMember/activate")]
        Task<StaffMemberUpdateResult> Activate(int id);

        [Put("/api/staffMember/deactivate")]
        Task<StaffMemberUpdateResult> Deactivate([Header("Authorization")] string authorization,int id);
    }
}
