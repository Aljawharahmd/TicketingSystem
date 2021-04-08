using System.Collections.Generic;
using Ticketing.Data.Enums;

namespace Ticketing.Data.Models
{
    public class Client  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AreaCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public List<Reply> Replies { get; set; }
        public List<Ticket> Tickets { get; set; }
     }
}
