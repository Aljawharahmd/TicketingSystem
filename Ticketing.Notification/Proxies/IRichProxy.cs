using System.Threading.Tasks;
using Refit;
using Ticketing.Notification.Models;

namespace Ticketing.Notification.Proxies
{
    public interface IRichProxy
    {
        [Post("/SendSmsLogin")]
        Task<RichResult> Send(RichParameter parameters);
    }
}
