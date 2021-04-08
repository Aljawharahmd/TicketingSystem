using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Persistence;

namespace Ticketing.Application.Services.Validation
{
    public class ClientValidation : IClientValidation
    {
        private readonly TicketingDbContext _dbContext;
        public ClientValidation(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserValidationStatus> ValidateCreateDuplicate(ClientCreateParameters parameters)
        {

            var findClientEmail = await _dbContext.Clients.AnyAsync(c => c.Email.Contains(parameters.Email));
            var findClientMobile = await _dbContext.Clients.AnyAsync(c => c.MobileNumber.Equals(parameters.MobileNumber));

            if (findClientEmail)
            {
                return UserValidationStatus.EmailAlreadyExists;

            }
            else if (findClientMobile)
            {
                return UserValidationStatus.MobileAlreadyExists;
            }
            else
            {
                return UserValidationStatus.Success;
            }
        }
        public async Task<UserValidationStatus> ValidateUpdateDuplicate(int id, ClientCreateParameters parameters)
        {

            var findClientEmail = await _dbContext.Clients.AnyAsync(c => (c.Id != id) && c.Email.Contains(parameters.Email));
            var findClientMobile = await _dbContext.Clients.AnyAsync(c => (c.Id != id) && c.MobileNumber.Equals(parameters.MobileNumber));

            if (findClientEmail)
            {
                return UserValidationStatus.EmailAlreadyExists;

            }
            else if (findClientMobile)
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
