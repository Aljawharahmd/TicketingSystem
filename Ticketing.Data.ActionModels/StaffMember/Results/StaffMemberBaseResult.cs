using System;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.StaffMember.Results
{
   public class StaffMemberBaseResult 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AreaCode { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
