using System.Threading.Tasks;
using Ticketing.Notification.Models;

namespace Ticketing.Notification.Abstraction
{
    public interface ISmsSender
    {
        /// <summary>
        /// This method sends an SMS code to the user mobile number using Rich API
        /// </summary>
        /// <param name="parameter">The mobile number and the SMS Code</param>
        /// <returns></returns>
        Task<bool> Send(SmsSendParameter parameter);
    }
}
