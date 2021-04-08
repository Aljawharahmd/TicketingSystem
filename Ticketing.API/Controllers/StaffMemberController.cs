using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.StaffMember.Parameters;
using Ticketing.Data.ActionModels.StaffMember.Results;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.API.Controllers
{
    [Route("api/staffMember")]
    [ApiController]
    public class StaffMemberController : Controller
    {
        private readonly IStaffMemberService _staffMemberService;

        public StaffMemberController(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;

        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string authorization)
        {
            var staff = await _staffMemberService.Get();
            if (staff == null)
            {
                return Ok(new List<StaffMemberViewResult>());
            }
            else
            {
                return Ok(staff);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet("getById")]
        public async Task<IActionResult> Get(string authorization, int id)
        {
            var staffMember = await _staffMemberService.Get(id);
            if (staffMember == null)
            {
                return Ok(new StaffMemberViewResult());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] StaffMemberCreateParameters parameters)
        {
            var staffMember = await _staffMemberService.Create(parameters);
            if (staffMember == null)
            {
                return Ok(new StaffMemberCreateResult());
            }
            return Ok(staffMember);
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpPut("update")]
        public async Task<IActionResult> Put(string authorization, int id, StaffMemberCreateParameters parameters)
        {
            var staffMember = await _staffMemberService.Update(id, parameters);
            if (staffMember == null)
            {
                return Ok(new StaffMemberUpdateResult());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [HttpPut("activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var staffMember = await _staffMemberService.Activate(id);
            if (staffMember == null)
            {
                return Ok(new StaffMemberUpdateResult());
            }
            else
            {
                return Ok(staffMember);
            }
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPut("deactivate")]
        public async Task<IActionResult> Deactivate(string authorization, int id)
        {
            var staffMember = await _staffMemberService.Deactivate(id);
            if (staffMember == null)
            {
                return Ok(new StaffMemberUpdateResult());
            }
            else
            {
                return Ok(staffMember);
            }
        }
    }
}
