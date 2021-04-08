using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class ReplyService : IReplyService
    {
        private readonly TicketingDbContext _dbContext;

        public ReplyService(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ReplyViewResult>> Get(ReplySearchParameters parameters)
        {
            var query = _dbContext.Replies.AsQueryable();

            if (parameters.StaffId.HasValue)
                query = query.Where(r => r.Employee.Id == parameters.StaffId);

            if (parameters.ClientId.HasValue)
                query = query.Where(r => r.Client.Id == parameters.ClientId);

            if (parameters.TicketId.HasValue)
                query = query.Where(r => r.Ticket.Id == parameters.TicketId);

            if (parameters.CreateDateTime.HasValue)
                query = query.Where(r => r.CreateDateTime.Equals(parameters.CreateDateTime));

            var replies = await query.Include(c => c.Client).Include(e => e.Employee).Include(t => t.Ticket).ToListAsync();

            if (replies == null || !replies.Any())
                return new List<ReplyViewResult>();

            var replyViewResult = new List<ReplyViewResult>();

            foreach (var reply in replies)
            {
                replyViewResult.Add(new ReplyViewResult
                {
                    Id = reply.Id,
                    Content = reply.Content,
                    CreateDateTime = reply.CreateDateTime,
                    StaffMemberName = reply.Employee?.Name,
                    ClientName = reply.Client?.Name,
                    TicketId = reply.Ticket.Id,
                    SenderType = reply.SenderType

                });
            }
            return replyViewResult;
        }
        public async Task<ReplyCreateResult> Create(ReplyCreateParameters parameters)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(p => p.Id == parameters.TicketId);
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == parameters.ClientId);
            var staff = await _dbContext.Staff.FirstOrDefaultAsync(e => e.Id == parameters.StaffId);
            if (ticket == null || client == null)
                return null;

            var result = await _dbContext.Replies.AddAsync(new Reply()
            {
                CreateDateTime = DateTime.Now,
                Content = parameters.Content,
                Client = client,
                Employee = staff,
                Ticket = ticket,
                SenderType = parameters.SenderType

            });
            await _dbContext.SaveChangesAsync();

            var reply = result.Entity;

            return new ReplyCreateResult()
            {
                Id = reply.Id,
                CreateDateTime = DateTime.Now.Date,
                Content = parameters.Content,
                ClientName = client.Name,
                StaffMemberName = staff?.Name,
                StaffMemberEmail = staff?.Email,
                TicketId = ticket.Id,
            };
        }
    }
}
