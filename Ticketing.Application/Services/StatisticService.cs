using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Statistic.Results;
using Ticketing.Data.Enums;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly TicketingDbContext _dbContext;

        public StatisticService(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetInprogressTicket()
        {
            return await _dbContext.Tickets.CountAsync(t => t.Status == TicketStatus.Inprogress);
        }
        public async Task<int> GetOpenTicket()
        {
            return await _dbContext.Tickets.CountAsync(t => t.Status == TicketStatus.Open);
        }
        public async Task<int> GetCloseTicket()
        {
            return await _dbContext.Tickets.CountAsync(t => t.Status == TicketStatus.Close);
        }
        public async Task<int> GetInprogressTicket(int staffMemberId)
        {
            return await _dbContext.Tickets.Include(t => t.Employee).CountAsync(t => t.Status == TicketStatus.Inprogress && t.Employee.Id == staffMemberId);
        }
        public async Task<int> GetSolveTicket(int staffMemberId)
        {
            return await _dbContext.Tickets.Include(t => t.Employee).CountAsync(t => t.Status == TicketStatus.Open && t.Employee.Id == staffMemberId);
        }
        public async Task<int> GetCloseTicket(int staffMemberId)
        {
            return await _dbContext.Tickets.Include(t => t.Employee).CountAsync(t => t.Status == TicketStatus.Close && t.Employee.Id == staffMemberId);
        }

        public async Task<int> GetAllClients()
        {
            return await _dbContext.Clients.CountAsync();
        }

        public async Task<MostProductiveEmployeeResult> MostProductiveEmployee()
        {
            var staffMemberId = await (from ticket in _dbContext.Tickets
                                       join employee in _dbContext.Staff on ticket.Employee.Id equals employee.Id
                                       where ticket.Status == TicketStatus.Close
                                       group ticket by ticket.Employee.Id into grouped
                                       select new
                                       {
                                           Id = grouped.Key,
                                           count = grouped.Count<Ticket>()
                                       }).OrderByDescending(g => g.count).Select(g => g.Id).FirstOrDefaultAsync();

            var staffMember = new MostProductiveEmployeeResult
            {
                Id = staffMemberId,
                Name = _dbContext.Staff.FirstOrDefault(e => e.Id == staffMemberId)?.Name,
            };
            if (staffMember == null)
            {
                return null;
            }
            return staffMember;
        }

        public async Task<int> AverageTicketsPerStaff()
        {
            var tickets = _dbContext.Tickets.Count();
            var staff = await _dbContext.Tickets.Where(t => t.Employee.Id != 0)
                                                    .Select(e => e.Employee.Id).CountAsync();
            var average = tickets / staff;
            if (average == 0)
            {
                return 0;
            }
            return average;
        }

        public async Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct(int staffMemberId)
        {
            var products = await (from ticket in _dbContext.Tickets
                                  where ticket.Employee.Id.Equals(staffMemberId)
                                  join product in _dbContext.Products on ticket.Product.Id equals product.Id
                                  group ticket by ticket.Product.Id into grouped
                                  select new
                                  {
                                      count = grouped.Count<Ticket>(),
                                      Id = grouped.Key

                                  }).ToListAsync();
            var productViewResults = new List<TicketsPerProductResult>();

            foreach (var item in products)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
                productViewResults.Add(new TicketsPerProductResult()
                {

                    NumberOfTickets = item.count,
                    ProductName = product.Name,
                });
            }
            return productViewResults;
        }

        public async Task<List<TicketsPerProductResult>> NumberOfTicketsPerProduct()
        {
            var products = await (from ticket in _dbContext.Tickets
                                  join product in _dbContext.Products on ticket.Product.Id equals product.Id
                                  group ticket by ticket.Product.Id into grouped
                                  select new
                                  {
                                      count = grouped.Count<Ticket>(),
                                      Id = grouped.Key

                                  }).ToListAsync();
            var productViewResults = new List<TicketsPerProductResult>();

            foreach (var item in products)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
                productViewResults.Add(new TicketsPerProductResult()
                {

                    NumberOfTickets = item.count,
                    ProductName = product.Name,
                });
            }
            return productViewResults;


        }

        public async Task<List<TicketPerStatusResult>> NumberOfTicketsStatus()
        {
            var tickets = await (from ticket in _dbContext.Tickets
                                 group ticket by ticket.Status into grouped
                                 select new
                                 {
                                     count = grouped.Count<Ticket>(),
                                     Id = grouped.Key
                                 }).ToListAsync();
            var productViewResults = new List<TicketPerStatusResult>();

            foreach (var item in tickets)
            {
                var status = await _dbContext.Tickets.FirstOrDefaultAsync(p => p.Status == item.Id);
                productViewResults.Add(new TicketPerStatusResult()
                {

                    Count = item.count,
                    Status = status.Status,
                });
            }
            return productViewResults;
        }

        public async Task<List<TicketsPerStaffResult>> NumberOfTicketsPerEmployee()
        {
            var tickets = await (from ticket in _dbContext.Tickets
                                 join employee in _dbContext.Staff on ticket.Employee.Id equals employee.Id
                                 group ticket by ticket.Employee.Id into grouped
                                 select new
                                 {
                                     Id = grouped.Key
                                 }).ToListAsync();
            var staffViewResults = new List<TicketsPerStaffResult>();

            foreach (var item in tickets)
            {
                var employee = await _dbContext.Staff.FirstOrDefaultAsync(p => p.Id == item.Id);
                var open = _dbContext.Tickets
                    .Count(t => t.Status.Equals(TicketStatus.Inprogress)
                                && t.Employee.Id == employee.Id);
                var closed = _dbContext.Tickets
                    .Count(t => t.Status.Equals(TicketStatus.Close)
                                && t.Employee.Id == employee.Id);
                staffViewResults.Add(new TicketsPerStaffResult()
                {
                    StaffName = employee.Name,
                    Open = open,
                    Closed = closed

                });
            }
            return staffViewResults;
        }
    }
}
