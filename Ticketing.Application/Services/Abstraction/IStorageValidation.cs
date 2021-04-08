using System.Threading.Tasks;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IStorageValidation
    {
        Task<bool> CanOpen(int id, int userId);
    }
}
