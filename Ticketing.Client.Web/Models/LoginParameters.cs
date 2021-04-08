using System.ComponentModel.DataAnnotations;

namespace Ticketing.Client.Web.Models
{
    public class LoginParameters
    {
        public string AreaCode { get; set; }
         public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}
