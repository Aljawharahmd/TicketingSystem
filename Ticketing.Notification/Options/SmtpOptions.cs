﻿namespace Ticketing.Notification.Options
{
    public class SmtpOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; } = "TickIT@support.com";
        public bool TestMood { get; set; }
    }
}
