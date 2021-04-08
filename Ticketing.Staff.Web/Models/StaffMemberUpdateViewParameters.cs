using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.Staff.Web.Models
{
    public class StaffMemberUpdateViewParameters
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AreaCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
