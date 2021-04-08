using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Data.ActionModels.Product.Results;
using Ticketing.Data.Models;
using Ticketing.Persistence;

namespace Ticketing.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly TicketingDbContext _dbContext;
        private readonly IProductValidation _productValidation;
        public ProductService(TicketingDbContext dbContext, IProductValidation productValidation)
        {
            _dbContext = dbContext;
            _productValidation = productValidation;
        }

        public async Task<List<ProductViewResult>> Get()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (!(products.Count > 0))
            {
                return null;
            }
            var productsViewResults = new List<ProductViewResult>();
            foreach (var product in products)
            {
                productsViewResults.Add(new ProductViewResult()
                {
                    Id = product.Id,
                    Name = product.Name,
                    TicketPriority = product.TicketPriority
                }); ;

            }
            return productsViewResults;
        }

        public async Task<ProductCreateResult> Create(ProductCreateParameters parameters)
        {
            if (!await _productValidation.CreateValidation(parameters))
            {
                return null;
            }

            var product = await _dbContext.Products.AddAsync(new Product
            {
                Name = parameters.Name,
                TicketPriority = parameters.TicketPriority

            });

            await _dbContext.SaveChangesAsync();

            return new ProductCreateResult()
            {
                Name = product.Entity.Name,
                Id = product.Entity.Id,
                TicketPriority = product.Entity.TicketPriority
            };
        }
        public async Task<ProductUpdateResult> Update(int id, ProductUpdateParameters parameters)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (!(await _productValidation.UpdateValidation(id, parameters)) || product == null)
                return null;


            product.Name = parameters.Name;
            product.TicketPriority = parameters.TicketPriority;

            await _dbContext.SaveChangesAsync();

            return new ProductUpdateResult
            {
                Name = product.Name,
                Id = product.Id,
                TicketPriority = product.TicketPriority
            };
        }
        public async Task<int> Delete(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return 0;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
