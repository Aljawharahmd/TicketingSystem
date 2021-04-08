using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.Client.Parameters;
using Ticketing.Data.ActionModels.Client.Results;
using Ticketing.Data.Enums;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly TicketingDbContext _dbContext;
        private readonly IClientValidation _clientValidation;

        public ClientService(TicketingDbContext dbContext,
                            IClientValidation clientValidation)
        {
            _dbContext = dbContext;
            _clientValidation = clientValidation;
        }

        public async Task<List<ClientViewResult>> Get()
        {
            var clients = await _dbContext.Clients
                 .Include(t => t.Tickets)
                 .AsQueryable().ToListAsync();

            if (clients == null)
                return null;

            var clientResult = new List<ClientViewResult>();

            foreach (var client in clients)
            {
                clientResult.Add(new ClientViewResult
                {
                    Id = client.Id,
                    Name = client.Name,
                    MobileNumber = client.MobileNumber,
                    AreaCode = client.AreaCode,
                    Status = client.Status,
                    Email = client.Email,

                    NumberOfTickets = client.Tickets.Count(t => t.Client.Id == client.Id)
                });
            }
            return clientResult;
        }
        public async Task<ClientViewResult> Get(int id)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(t => t.Id == id);

            if (client == null)
                return null;

            return new ClientViewResult
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                MobileNumber = client.MobileNumber,
                AreaCode = client.AreaCode,
            };
        }
        public async Task<ClientCreateResult> Create(ClientCreateParameters parameters)
        {
            var validation = await _clientValidation.ValidateCreateDuplicate(parameters);
            if (validation != UserValidationStatus.Success)
            {
                return null;
            }
            else
            {
                var result = await _dbContext.Clients.AddAsync(new Client()
                {
                    Name = parameters.Name,
                    MobileNumber = parameters.MobileNumber,
                    AreaCode = parameters.AreaCode,
                    Email = parameters.Email,
                    Password = parameters.Password,
                    Status = UserStatus.Inactive,
                });
                await _dbContext.SaveChangesAsync();

                var client = result.Entity;

                return new ClientCreateResult()
                {
                    Id = client.Id,
                    Name = client.Name,
                    MobileNumber = client.MobileNumber,
                    AreaCode = client.AreaCode,
                    Email = client.Email,
                };
            }
        }
        public async Task<ClientUpdateResult> Update(int id, ClientCreateParameters parameters)
        {
            var validation = await _clientValidation.ValidateUpdateDuplicate(id, parameters);
            if (validation != UserValidationStatus.Success)
            {
                return null;
            }

            var client = await _dbContext.Clients
                  .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return null;
            }
            client.Name = parameters.Name;
            client.MobileNumber = parameters.MobileNumber;
            client.AreaCode = parameters.AreaCode;
            client.Email = parameters.Email;
            client.Password = parameters.Password;

            await _dbContext.SaveChangesAsync();
            return new ClientUpdateResult()
            {
                Id = client.Id,
                Name = client.Name,
                MobileNumber = client.MobileNumber,
                AreaCode = client.AreaCode,
                Email = client.Email
            };
        }
        public async Task<ClientUpdateResult> Activate(int id)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);
            if (client == null)
            {
                return null;
            }
            client.Status = UserStatus.Active;
            await _dbContext.SaveChangesAsync();

            return new ClientUpdateResult()
            {
                Id = client.Id,
                Name = client.Name,
                MobileNumber = client.MobileNumber,
                AreaCode = client.AreaCode,
                Email = client.Email,
                Status = client.Status
            };
        }
        public async Task<ClientUpdateResult> Deactivate(int id)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);
            if (client == null)
            {
                return null;
            }
            client.Status = UserStatus.Inactive;
            await _dbContext.SaveChangesAsync();

            return new ClientUpdateResult()
            {
                Id = client.Id,
                Name = client.Name,
                MobileNumber = client.MobileNumber,
                AreaCode = client.AreaCode,
                Email = client.Email,
                Status = client.Status
            };
        }
    }
}