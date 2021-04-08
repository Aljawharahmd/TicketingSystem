using Ticketing.Notification.Models;

namespace Ticketing.Notification.Abstraction
{
    public interface IEmailSender
    {
        /// <summary>
        /// This method sends an email to the user in a specific event
        /// </summary>
        /// <param name="parameter">The target email, subject and body</param>
        /// <returns></returns>
        bool Send(EmailSendParameter parameter);
    }
}
