using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Models;
using Ticketing.Notification.Options;

namespace Ticketing.Notification.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly SmtpOptions _options;

        public EmailSender(IOptions<SmtpOptions> options, ILogger<EmailSender> logger)
        {
            _options = options.Value;
            _logger = logger;
        }
        public bool Send(EmailSendParameter parameter)
        {
            try
            {
                if (_options.TestMood)
                {
                    _logger.LogDebug("EmailSender, Send, test mood", _options.TestMood);
                    return true;
                }
                _logger.LogDebug("EmailSender, Send, Parameters:{parameter}", JsonConvert.SerializeObject(parameter));
                using (var client = new SmtpClient(_options.Server, _options.Port))
                {
                    client.Credentials = new NetworkCredential(_options.Username, _options.Password);

                    var message = new MailMessage(new MailAddress(_options.Sender),
                        new MailAddress(parameter.ToAddress))
                    {
                        Subject = parameter.Subject, Body = parameter.Body, IsBodyHtml = true
                    };

                    client.Send(message);
                    return true;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to Send email to: {email}", parameter.ToAddress);
                return false;
            }
        }
    }
}
