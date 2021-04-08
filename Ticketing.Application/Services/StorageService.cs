using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Storage.Result;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly TicketingDbContext _dbContext;

        public StorageService(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StorageViewResult> Create(StorageCreateParameters parameters)
        {

            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == parameters.TicketId);


            var result = await _dbContext.StorageFiles.AddAsync(new StorageFile
            {
                Extension = parameters.Extension,
                Name = parameters.Name,
                Ticket = ticket
            });

            await _dbContext.SaveChangesAsync();
            return new StorageViewResult
            {
                Id = result.Entity.Id,
                Extension = result.Entity.Extension,
                Name = result.Entity.Name,

            };
        }
        public async Task<StorageViewResult> Create(int id, StorageCreateParameters parameters)
        {

            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == parameters.TicketId);
            var reply = await _dbContext.Replies.FirstOrDefaultAsync(r => r.Id == id);

            var result = await _dbContext.StorageFiles.AddAsync(new StorageFile
            {
                Extension = parameters.Extension,
                Name = parameters.Name,
                Reply = reply,
                Ticket = ticket
            });

            await _dbContext.SaveChangesAsync();
            return new StorageViewResult
            {
                Id = result.Entity.Id,
                Extension = result.Entity.Extension,
                Name = result.Entity.Name,
            };
        }

        public async Task<List<StorageViewResult>> Get(StorageSearchParameters parameters)
        {
            var query = _dbContext.StorageFiles.AsQueryable();

            if (parameters.ReplyId.HasValue)
                query = query.Where(s => s.Reply.Id == parameters.ReplyId);
            if (parameters.TicketId.HasValue)
                query = query.Where(s => s.Ticket.Id == parameters.TicketId);
            var files = await query.ToListAsync();
            if (files.Count == 0)
                return null;
            var storageViewResults = new List<StorageViewResult>();
            foreach (var file in files)
            {
                storageViewResults.Add(new StorageViewResult
                {
                    Id = file.Id,
                    Extension = file.Extension,
                    Name = file.Name
                });

            }
            return storageViewResults;
        }
        public async Task<List<StorageViewResult>> Get(int ticketId)
        {
            var files = await _dbContext.StorageFiles.Where(s => s.Ticket.Id == ticketId && s.Reply.Id.ToString() == null).ToListAsync();

            if (!files.Any())
                return null;
            var storageViewResults = new List<StorageViewResult>();

            foreach (var file in files)
            {
                storageViewResults.Add(new StorageViewResult
                {
                    Id = file.Id,
                    Extension = file.Extension,
                    Name = file.Name
                });
            }
            return storageViewResults;
        }
    }
}
