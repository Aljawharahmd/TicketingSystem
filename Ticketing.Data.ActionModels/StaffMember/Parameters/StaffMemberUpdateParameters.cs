using System;

namespace Ticketing.Data.ActionModels.StaffMember.Parameters
{
    public class StaffMemberUpdateParameters : StaffMemberBaseParameters
    {
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
