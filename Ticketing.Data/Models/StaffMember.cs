using System;
using System.Collections.Generic;
using Ticketing.Data.Enums;

namespace Ticketing.Data.Models
{
    public class StaffMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AreaCode { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public StaffMemberRole Role { get; set; }
        public UserStatus Status { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
