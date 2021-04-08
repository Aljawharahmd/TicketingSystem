using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ticketing.Data.Enums;
using Ticketing.Persistence;
using Ticketing.Security.Authentication.Abstractions;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model.Parameters;
using Ticketing.Security.Authentication.Model.Results;
using Ticketing.Trace.Abstraction;

namespace Ticketing.Security.Authentication.Validation
{
    public class UserManagerAuthentication : IUserManagerAuthentication
    {
        private readonly ILogger<UserManagerAuthentication> _logger;
        private readonly TicketingDbContext _dbContext;
        private readonly IRequestTrace _requestTrace;

        public UserManagerAuthentication(
            ILogger<UserManagerAuthentication> logger,
             TicketingDbContext dbContext,
            IRequestTrace requestTrace)
        {
            _logger = logger;
            _dbContext = dbContext;
            _requestTrace = requestTrace;
        }

        public async Task<AuthenticationContext> Get(AuthenticationParameters parameters)
        {
            _logger.LogDebug($"{_requestTrace.Id} => UserManagerAuthentication: Get Method with parameters: {parameters}", JsonConvert.SerializeObject(parameters));

            if (parameters.Type == UserType.Client)
                return await GetClient(parameters);

            return await GetStaff(parameters);


        }
        public async Task<AuthenticationContext> Get(int id, UserType type)
        {
            _logger.LogDebug($"{_requestTrace.Id} => UserManagerAuthentication, Get Method with parameters: {id}, type: {type}", id, type);

            if (type == UserType.Client)
                return await GetClient(id);

            return await GetStaff(id);
        }


        private async Task<AuthenticationContext> GetStaff(int id)
        {

            var staff = await _dbContext.Staff.FirstOrDefaultAsync(e => e.Id == id);

            if (staff != null)
            {
                return new AuthenticationContext
                {
                    UserId = staff.Id,
                    Type = staff.Role == StaffMemberRole.Manager ? UserType.Manager : UserType.Staff,
                    RequiredMethods = new List<AuthenticationMethod> { AuthenticationMethod.Biometrics }
                };
            }
            else
                return null;
        }
        private async Task<AuthenticationContext> GetClient(int id)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);

            if (client != null)
            {
                return new AuthenticationContext
                {
                    UserId = client.Id,
                    Type = UserType.Client
                };
            }
            else
                return null;
        }

        private async Task<AuthenticationContext> GetStaff(AuthenticationParameters parameters)
        {
            var staff = await _dbContext.Staff.FirstOrDefaultAsync(e => e.MobileNumber.Equals(parameters.Identifier)
                                                                    && e.AreaCode.Equals(parameters.AreaCode)
                                                                    && e.Status == UserStatus.Active);
            if (staff == null)
                return null;

            return new AuthenticationContext
            {
                UserId = staff.Id,
                Type = staff.Role == StaffMemberRole.Manager ? UserType.Manager : UserType.Staff,
                RequiredMethods = new List<AuthenticationMethod> { AuthenticationMethod.Biometrics }
            };
        }
        private async Task<AuthenticationContext> GetClient(AuthenticationParameters parameters)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.MobileNumber.Equals(parameters.Identifier)
                                                                      && c.AreaCode.Equals(parameters.AreaCode)
                                                                      && c.Password.Equals(parameters.Password) 
                                                                      && c.Status == UserStatus.Active);
            if (client == null)
                return null;

            return new AuthenticationContext
            {
                UserId = client.Id,
                Type = UserType.Client
            };
        }

    }
}