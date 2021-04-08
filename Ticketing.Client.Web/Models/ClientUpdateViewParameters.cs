namespace Ticketing.Client.Web.Models
{
    public class ClientUpdateViewParameters
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AreaCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
