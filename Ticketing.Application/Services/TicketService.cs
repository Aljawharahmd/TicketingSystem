using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Ticket.Parameters;
using Ticketing.Data.ActionModels.Ticket.Results;
using Ticketing.Data.Enums;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class TicketService : ITicketService

    {
        private readonly TicketingDbContext _dbContext;
        public TicketService(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TicketViewResult>> Get()
        {
            var tickets = await _dbContext.Tickets.Include(t => t.Product)
                         .Include(t => t.Client).Include(t => t.Employee)
                         .ToListAsync();
            if (!(tickets.Count > 0))
            {
                return null;
            }
            var ticketsViewResults = new List<TicketViewResult>();
            foreach (var ticket in tickets)
            {

                ticketsViewResults.Add(new TicketViewResult
                {
                    Id = ticket.Id,
                    ClientName = ticket.Client?.Name,
                    StaffMemberName = ticket.Employee?.Name,
                    ProductName = ticket.Product?.Name,
                    Priority = ticket.Priority,
                    Status = ticket.Status,
                    Summary = ticket.Summary,
                    Subject = ticket.Subject,
                    CreateDateTime = ticket.CreateDateTime,
                    LastModifiedDateTime = LastModified(ticket.Id),
                });
            }
            return ticketsViewResults;
        }
        public async Task<TicketViewResult> Get(int id)
        {
            var ticket = await _dbContext.Tickets.Include(t => t.Product)
                         .Include(t => t.Client).Include(t => t.Employee).FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
                return null;

            return new TicketViewResult
            {
                Id = ticket.Id,
                ClientId = ticket.Client.Id,
                ClientName = ticket.Client?.Name,
                StaffMemberId = ticket.Employee?.Id,
                StaffMemberName = ticket.Employee?.Name,
                ClientEmail = ticket.Client?.Email,
                ProductName = ticket.Product.Name,
                Priority = ticket.Priority,
                Status = ticket.Status,
                Subject = ticket.Subject,
                Summary = ticket.Summary,
                CreateDateTime = ticket.CreateDateTime,
                LastModifiedDateTime = LastModified(ticket.Id)
            };
        }
        public async Task<List<TicketViewResult>> Get(TicketSearchParameters parameters)
        {
            var query = _dbContext.Tickets.AsQueryable();

            if (parameters.Id.HasValue)
                query = query.Where(t => t.Id == parameters.Id);
            if (parameters.EmployeeId.HasValue)
                query = query.Where(t => t.Employee.Id == parameters.EmployeeId);
            if (parameters.ProductId.HasValue)
                query = query.Where(t => t.Product.Id == parameters.ProductId);
            if (parameters.ClientId.HasValue)
                query = query.Where(t => t.Client.Id == parameters.ClientId);
            if (parameters.Status.HasValue)
                query = query.Where(t => t.Status == parameters.Status);

            var tickets = await query.Include(c => c.Client).Include(e => e.Employee).Include(p => p.Product).ToListAsync();

            if (!tickets.Any())
                return null;

            var ticketViewResult = new List<TicketViewResult>();
            foreach (var ticket in tickets)
            {
                ticketViewResult.Add(new TicketViewResult
                {
                    Id = ticket.Id,
                    ClientName = ticket.Client?.Name,
                    StaffMemberName = ticket.Employee?.Name,
                    ProductName = ticket.Product?.Name,
                    Priority = ticket.Priority,
                    Status = ticket.Status,
                    Summary = ticket.Summary,
                    Subject = ticket.Subject,
                    CreateDateTime = ticket.CreateDateTime,
                    LastModifiedDateTime = LastModified(ticket.Id),

                });
            }
            return ticketViewResult;
        }
        public async Task<TicketCreateResult> Create(TicketCreateParameters parameters)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == parameters.ProductId);
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == parameters.ClientId);
            if (product == null || client == null)
                return null;

            var result = await _dbContext.Tickets.AddAsync(new Ticket()
            {
                Subject = parameters.Subject,
                Summary = parameters.Summary,
                Status = TicketStatus.Open,
                Priority = product.TicketPriority,
                CreateDateTime = DateTime.Now,
                Product = product,
                Client = client,

            });
            await _dbContext.SaveChangesAsync();

            return new TicketCreateResult()
            {
                Id = result.Entity.Id,
                Subject = result.Entity.Subject,
                Summary = result.Entity.Summary,
                Status = result.Entity.Status,
                ProductName = product.Name,
                ClientName = client.Name,
                Priority = result.Entity.Priority,
                CreateDateTime = result.Entity.CreateDateTime,



            };
        }
        public async Task<TicketUpdateResult> Update(int id)
        {
            var ticket = await _dbContext.Tickets.Include(t => t.Employee)
                         .Include(t => t.Client).FirstOrDefaultAsync(t => t.Id == id && t.Status != TicketStatus.Close);

            ticket.Status = TicketStatus.Close;
            ticket.CloseDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return new TicketUpdateResult()
            {
                Summary = ticket.Summary,
                Status = ticket.Status,
                ClientName = ticket.Client.Name,
                StaffMemberName = ticket.Employee?.Name,
                Priority = ticket.Priority,
                CreateDateTime = ticket.CreateDateTime,
                CloseDate = ticket.CloseDate,
                Id = ticket.Id,
            };
        }
        public async Task<TicketUpdateResult> Update(int id, int assignedTo, TicketPriority priority)
        {
            var ticket = await _dbContext.Tickets.Include(t => t.Product)
                .Include(t => t.Client).FirstOrDefaultAsync(p => p.Id == id);

            var staffMember = await _dbContext.Staff.FirstOrDefaultAsync(e => e.Id == assignedTo);

            if (staffMember == null && ticket.Employee == null)
            {
                ticket.Priority = priority;
                ticket.Employee = null;


            }
            else if (staffMember == null && ticket.Employee != null)
            {
                ticket.Priority = priority;

            }
            else
            {
                ticket.Priority = priority;
                ticket.Employee = staffMember;
                ticket.Status = TicketStatus.Inprogress;
            }
            await _dbContext.SaveChangesAsync();

            return new TicketUpdateResult()
            {
                Summary = ticket.Summary,
                Status = ticket.Status,
                ProductName = ticket.Product.Name,
                ClientName = ticket.Client.Name,
                Priority = ticket.Priority,
                CreateDateTime = ticket.CreateDateTime,
                CloseDate = ticket.CloseDate,
                Id = ticket.Id,
            };
        }
        public async Task CloseUnUsed()
        {
            var tickets = await _dbContext.Tickets
                .Include(t => t.Replies)
                .Where(t =>
                    t.Status != TicketStatus.Close &&
                    t.CreateDateTime < DateTime.Now.AddDays(-10) &&
                    (t.Replies == null ||
                    !t.Replies.Any() ||
                    t.Replies
                        .Select(c => c.CreateDateTime)
                        .OrderByDescending(r => r)
                        .FirstOrDefault() < DateTime.Now.AddDays(-10)
                    )
                )
                .ToListAsync();

            if (!tickets.Any())
                return;

            foreach (var ticket in tickets)
            {
                ticket.Status = TicketStatus.Close;
                ticket.CloseDate = DateTime.Now;
            }

            await _dbContext.SaveChangesAsync();
        }
        private async Task<DateTime?> LastModified(int id)
        {
            var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            var lastReply = await _dbContext.Replies.OrderByDescending(r => r.Id)
                .Where(r => r.Ticket.Id == ticket.Id).FirstOrDefaultAsync();

            if (ticket.CloseDate != null)
            {
                return ticket.CloseDate;
            }
            else if (lastReply != null)
            {
                return lastReply.CreateDateTime;
            }
            else
            {
                return ticket.CreateDateTime;
            }
        }
    }
}
