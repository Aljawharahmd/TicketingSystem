using Microsoft.AspNetCore.Http;
using Ticketing.Security.Authentication.Model.Results;

namespace Ticketing.Staff.Web.Models
{
    public class BiometricsParameters
    {
        public AuthenticationContext Context { get; set; }
        public IFormFile Face { get; set; }
        public IFormFile Voice { get; set; }
    }
}
