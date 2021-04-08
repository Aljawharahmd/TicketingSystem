using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Statistic.Results;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.API.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("GetInprogressTicket")]
        public async Task<IActionResult> GetInprogressTicket(string authorization)
        {
            var staffMember = await _statisticService.GetInprogressTicket();
            if (staffMember == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet("GetInprogressTicket/{staffMemberId}")]
        public async Task<IActionResult> GetInprogressTicket(string authorization, int staffMemberId)
        {
            var staffMember = await _statisticService.GetInprogressTicket(staffMemberId);
            if (staffMember == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("GetOpenTicket")]
        public async Task<IActionResult> GetOpenTicket(string authorization)
        {
            var staffMember = await _statisticService.GetOpenTicket();
            if (staffMember == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("GetCloseTicket")]
        public async Task<IActionResult> GetCloseTicket(string authorization)
        {
            var employee = await _statisticService.GetCloseTicket();
            if (employee == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(employee);
            }
        }

        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet("GetCloseTicket/{staffMemberId}")]
        public async Task<IActionResult> GetCloseTicket(string authorization, int staffMemberId)
        {
            var staffMember = await _statisticService.GetCloseTicket(staffMemberId);
            if (staffMember == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients(string authorization)
        {
            var staffMember = await _statisticService.GetAllClients();
            if (staffMember == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]

        [HttpGet("MostProductive")]
        public async Task<IActionResult> GetMostProductive(string authorization)
        {
            var staffMember = await _statisticService.MostProductiveEmployee();
            if (staffMember == null)
            {
                return Ok(new MostProductiveEmployeeResult());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("NumberOfTicketsPerProduct")]
        public async Task<IActionResult> NumberOfTicketsPerProduct(string authorization)
        {
            var product = await _statisticService.NumberOfTicketsPerProduct();
            if (product == null)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(product);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("AverageTicketsPerStaff")]
        public async Task<IActionResult> AverageTicketsPerStaff(string authorization)
        {
            var product = await _statisticService.AverageTicketsPerStaff();
            if (product == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(product);
            }
        }

        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet("NumberOfTicketsPerProduct/{staffMemberId}")]
        public async Task<IActionResult> NumberOfTicketsPerProduct(string authorization, int staffMemberId)
        {
            var product = await _statisticService.NumberOfTicketsPerProduct(staffMemberId);
            if (product == null)
            {
                return Ok(new List<TicketsPerProductResult>());
            }
            else
            {
                return Ok(product);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("NumberOfTicketsStatus")]
        public async Task<IActionResult> NumberOfTicketsStatus(string authorization)
        {
            var tickets = await _statisticService.NumberOfTicketsStatus();
            if (tickets == null)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(tickets);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("NumberOfTicketsPerEmployee")]
        public async Task<IActionResult> NumberOfTicketsPerEmployee(string authorization)
        {
            var tickets = await _statisticService.NumberOfTicketsPerEmployee();
            if (tickets == null)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(tickets);
            }
        }

        [Authorize(Rules = new[] { UserType.Staff })]
        [HttpGet("GetSolveTicket/{staffMemberId}")]
        public async Task<IActionResult> GetSolveTicket(string authorization, int staffMemberId)
        {
            var tickets = await _statisticService.GetSolveTicket(staffMemberId);
            if (tickets == 0)
            {
                return Ok(new int());
            }
            else
            {
                return Ok(tickets);
            }
        }
    }
}

