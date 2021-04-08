using System;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.StaffMember.Parameters
{
    public class StaffMemberCreateParameters: StaffMemberBaseParameters
    {
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public StaffMemberRole Role { get; set; }
        public byte[] Image { get; set; }
        public byte[] Voice { get; set; }

    }
}
