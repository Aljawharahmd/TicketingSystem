using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Data.ActionModels.Product.Results;

namespace Ticketing.API.Proxies
{
    public interface IProductProxy
    {
        [Get("/api/products/Get")]
        Task<List<ProductViewResult>> Get([Header("Authorization")] string authorization);

        [Post("/api/products/create")]
        Task<ProductCreateResult> Create([Header("Authorization")] string authorization,ProductCreateParameters parameters);

        [Put("/api/products/update")]
        Task<ProductUpdateResult> Update([Header("Authorization")] string authorization,int id, ProductUpdateParameters parameters);

        [Delete("/api/products/delete")]
        Task<int> Delete([Header("Authorization")] string authorization, int id);
    }
}
