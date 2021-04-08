using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Persistence;

namespace Ticketing.Application.Services.Validation
{
    public class StorageValidation : IStorageValidation
    {
        private readonly TicketingDbContext _dbContext;

        public StorageValidation(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CanOpen(int id, int userId)
        {
            if (await _dbContext.Staff.FirstOrDefaultAsync(s => s.Id == userId) != null)
                return true;

            return await _dbContext.StorageFiles
                .Include(s => s.Ticket)
                .ThenInclude(t => t.Client)
                .AnyAsync(s => s.Id == id && s.Ticket.Client.Id == userId);
        }
    }
}
