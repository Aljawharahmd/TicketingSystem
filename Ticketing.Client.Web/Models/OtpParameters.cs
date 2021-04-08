namespace Ticketing.Client.Web.Models
{
    public class OtpParameters
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int ThirdNumber { get; set; }
        public int FourthNumber { get; set; }
    }
}
