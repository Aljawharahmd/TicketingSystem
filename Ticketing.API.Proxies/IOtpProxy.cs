using System.Threading.Tasks;
using Refit;
using Ticketing.Protection.Models;

namespace Ticketing.API.Proxies
{
    public interface IOtpProxy
    {
        [Post("/api/otp/Generate")]
        Task<string> Generate(OtpGenerateParameter id);

        [Post("/api/otp/validate")]
        Task<string> Validate(int id);   
    }
}
