using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Data.ActionModels.Product.Results;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IProductService
    {
        Task<List<ProductViewResult>> Get();
        Task<ProductCreateResult> Create(ProductCreateParameters parameters);
        Task<ProductUpdateResult> Update(int id, ProductUpdateParameters parameters);
        Task<int> Delete(int id);
    }
}
