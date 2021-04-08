using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Data.ActionModels.StaffMember.Results;
using Ticketing.Data.Enums;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class StaffMemberService : IStaffMemberService
    {
        private readonly TicketingDbContext _dbContext;
        private readonly IStaffMemberValidation _staffValidation;

        public StaffMemberService(TicketingDbContext dbContext, IStaffMemberValidation employeeValidation)
        {
            _dbContext = dbContext;
            _staffValidation = employeeValidation;
        }
        public async Task<List<StaffMemberViewResult>> Get()
        {
            var employees = await _dbContext.Staff
                 .AsQueryable().ToListAsync();

            if (employees == null || !employees.Any())
                return null;

            var employeeViewResult = new List<StaffMemberViewResult>();
            foreach (var employee in employees)
            {
                employeeViewResult.Add(new StaffMemberViewResult
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    MobileNumber = employee.MobileNumber,
                    Email = employee.Email,
                    BirthDate = employee.BirthDate,
                    Address = employee.Address,
                    Role = employee.Role,
                    Status = employee.Status

                });
            }
            return employeeViewResult;
        }
        public async Task<StaffMemberViewResult> Get(int id)
        {
            var staffMember = await _dbContext.Staff.FirstOrDefaultAsync(t => t.Id == id);
            if (staffMember == null)
                return null;

            return new StaffMemberViewResult
            {
                Id = staffMember.Id,
                Name = staffMember.Name,
                Email = staffMember.Email,
                MobileNumber = staffMember.MobileNumber,
                Address = staffMember.Address,
                BirthDate = staffMember.BirthDate,
                Role = staffMember.Role
            };
        }
        public async Task<StaffMemberCreateResult> Create(StaffMemberCreateParameters parameters)
        {
            var validation = await _staffValidation.ValidateCreateDuplicate(parameters);
            if (validation != UserValidationStatus.Success)
            {
                return null;
            }
            else
            {
                var result = await _dbContext.Staff.AddAsync(new StaffMember()
                {
                    Name = parameters.Name,
                    MobileNumber = parameters.MobileNumber,
                    AreaCode = parameters.AreaCode,
                    Email = parameters.Email,
                    BirthDate = parameters.BirthDate.Date,
                    Address = parameters.Address,
                    Role = StaffMemberRole.Employee,
                    Status = UserStatus.Inactive
                });
                await _dbContext.SaveChangesAsync();

                var staff = result.Entity;

                return new StaffMemberCreateResult()
                {
                    Id = staff.Id,
                    Name = parameters.Name,
                    MobileNumber = parameters.MobileNumber,
                    AreaCode = parameters.AreaCode,
                    Email = parameters.Email,
                    Address = parameters.Address,
                    Role = staff.Role,

                };
            }
        }
        public async Task<StaffMemberUpdateResult> Update(int id, StaffMemberCreateParameters parameters)
        {
            var validation = await _staffValidation.ValidateUpdateDuplicate(id, parameters);
            if (validation != UserValidationStatus.Success)
            {
                return null;
            }

            var staffMember = await _dbContext.Staff
                       .FirstOrDefaultAsync(c => c.Id == id);

            if (staffMember == null)
            {
                return null;
            }
            staffMember.Name = parameters.Name;
            staffMember.MobileNumber = parameters.MobileNumber;
            staffMember.Email = parameters.Email;
            staffMember.Address = parameters.Address;
            staffMember.BirthDate = parameters.BirthDate;
            await _dbContext.SaveChangesAsync();

            return new StaffMemberUpdateResult()
            {
                Id = staffMember.Id,
                Name = staffMember.Name,
                MobileNumber = staffMember.MobileNumber,
                Email = staffMember.Email,
                Address = staffMember.Address,
                BirthDate = staffMember.BirthDate
            };
        }
        public async Task<StaffMemberUpdateResult> Activate(int id)
        {
            var staffMember = await _dbContext.Staff.FirstOrDefaultAsync(e => e.Id == id);
            if (staffMember == null)
            {
                return null;
            }

            staffMember.Status = UserStatus.Active;
            await _dbContext.SaveChangesAsync();

            return new StaffMemberUpdateResult()
            {
                Id = staffMember.Id,
                Name = staffMember.Name,
                MobileNumber = staffMember.MobileNumber,
                Email = staffMember.Email,
                Status = staffMember.Status
            };
        }
        public async Task<StaffMemberUpdateResult> Deactivate(int id)
        {
            var staffMember = await _dbContext.Staff.FirstOrDefaultAsync(e => e.Id == id);
            if (staffMember == null)
            {
                return null;
            }

            staffMember.Status = UserStatus.Inactive;
            await _dbContext.SaveChangesAsync();

            return new StaffMemberUpdateResult()
            {
                Id = staffMember.Id,
                Name = staffMember.Name,
                MobileNumber = staffMember.MobileNumber,
                Email = staffMember.Email,
                Status = staffMember.Status
            };
        }
    }
}