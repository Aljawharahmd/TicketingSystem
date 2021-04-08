using System;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.StaffMember.Results
{
    public class StaffMemberCreateResult: StaffMemberBaseResult
    {
        public StaffMemberRole Role { get; set; }
    }
}
