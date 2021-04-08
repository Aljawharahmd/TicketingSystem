namespace Ticketing.Notification.Options
{
    public class SmsOptions
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
        public bool TestMood { get; set; }
    }
}
