using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Data.ActionModels.StaffMember.Results;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IStaffMemberService
    {
        Task<List<StaffMemberViewResult>> Get();
        Task<StaffMemberViewResult> Get(int id);
        Task<StaffMemberCreateResult> Create(StaffMemberCreateParameters parameters);
        Task<StaffMemberUpdateResult> Update(int id, StaffMemberCreateParameters parameters);
        Task<StaffMemberUpdateResult> Activate(int id);
        Task<StaffMemberUpdateResult> Deactivate(int id);
    }
}