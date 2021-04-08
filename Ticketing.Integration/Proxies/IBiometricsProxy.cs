using System.Threading.Tasks;
using Refit;
using Ticketing.Integration.Models;

namespace Ticketing.Integration.Proxies
{
    public interface IBiometricsProxy
    {
        [Post("/api/MMA/RecognizeBytes")]
        Task<BiometricsApiResult> Detect([Header("ServiceKey")]string serviceKey, BiometricsDetectionParameter parameter);
    }
}