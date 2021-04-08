using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Client.Results
{
    public class ClientBaseResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string AreaCode { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}
