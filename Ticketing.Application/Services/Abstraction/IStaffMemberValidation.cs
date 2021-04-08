using System.Threading.Tasks;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.StaffMember.Parameters;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IStaffMemberValidation
    {
        Task<UserValidationStatus> ValidateCreateDuplicate(StaffMemberCreateParameters parameters);
        Task<UserValidationStatus> ValidateUpdateDuplicate(int id, StaffMemberCreateParameters parameters);
    }
}
