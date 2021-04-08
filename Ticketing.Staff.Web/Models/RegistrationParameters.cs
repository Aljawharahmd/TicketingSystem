using Microsoft.AspNetCore.Http;

namespace Ticketing.Staff.Web.Models
{
    public class RegistrationParameters
    {
        public int StaffId { get; set; }
        public string Email { get; set; }
        public IFormFile Face { get; set; }
        public IFormFile Voice { get; set; }

    }
}
