using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Persistence;

namespace Ticketing.Application.Services.Validation
{
    public class StaffMemberValidation : IStaffMemberValidation
    {
        private readonly TicketingDbContext _dbContext;
        public StaffMemberValidation(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserValidationStatus> ValidateCreateDuplicate(StaffMemberCreateParameters parameters)
        {
            var findEmployeeEmail = await _dbContext.Staff.AnyAsync(c => c.Email.Contains(parameters.Email));
            var findEmployeeMobile = await _dbContext.Staff.AnyAsync(c => c.MobileNumber.Equals(parameters.MobileNumber));

            if (findEmployeeEmail)
            {
                return UserValidationStatus.EmailAlreadyExists;

            }
            else if (findEmployeeMobile)
            {
                return UserValidationStatus.MobileAlreadyExists;
            }
            else
            {
                return UserValidationStatus.Success;
            }
        }
        public async Task<UserValidationStatus> ValidateUpdateDuplicate(int id, StaffMemberCreateParameters parameters)
        {
            var findEmployeeEmail = await _dbContext.Staff.AnyAsync(c => (c.Id != id) && c.Email.Contains(parameters.Email));
            var findEmployeeMobile = await _dbContext.Staff.AnyAsync(c => (c.Id != id) && c.MobileNumber.Equals(parameters.MobileNumber));

            if (findEmployeeEmail)
            {
                return UserValidationStatus.EmailAlreadyExists;

            }
            else if (findEmployeeMobile)
            {
                return UserValidationStatus.MobileAlreadyExists;
            }
            else
            {
                return UserValidationStatus.Success;
            }
        }
    }
}
