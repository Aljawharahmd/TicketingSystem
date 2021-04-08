using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Files.Parameters;

namespace Ticketing.API.Proxies
{
   public interface IFileProxy
    {
        [Get("/api/files/{id}")]
        Task<byte[]> Get([Header("Authorization")] string authorization, int id);

        [Get("/api/files/GetFace")]
        Task<byte[]> GetFace([Header("Authorization")] string authorization, int staffId);

        [Get("/api/files/GetVoice")]
        Task<byte[]> GetVoice([Header("Authorization")] string authorization, int staffId);

        [Post("/api/files/Upload")]
        Task Upload([Header("Authorization")] string authorization, FileUploadParameters parameters);
    }
}
