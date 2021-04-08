using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Persistence;

namespace Ticketing.Application.Services.Validation
{
    public class ProductValidation : IProductValidation
    {
        private readonly TicketingDbContext _dbContext;

        public ProductValidation(TicketingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateValidation(ProductCreateParameters parameters)
        {
            var findProductName = await _dbContext.Products.AnyAsync(p => p.Name.ToLower().Equals(parameters.Name.ToLower()));

            if (!string.IsNullOrEmpty(parameters.Name) && !(findProductName))
                return true;
            return false;
        }

        public async Task<bool> UpdateValidation(int id, ProductUpdateParameters parameters)
        {
            bool findProductName = await _dbContext.Products.AnyAsync(p => (p.Id != id) && p.Name.ToLower().Equals(parameters.Name.ToLower()));
            if (findProductName)
                return false;
            return true;

        }
    }

}
