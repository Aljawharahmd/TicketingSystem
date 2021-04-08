using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IProductValidation
    {
        Task<bool> CreateValidation(ProductCreateParameters parameters);
        Task<bool> UpdateValidation(int id, ProductUpdateParameters parameters);
    }
}
