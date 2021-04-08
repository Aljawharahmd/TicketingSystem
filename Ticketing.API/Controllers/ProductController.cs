using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Data.ActionModels.Product.Results;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;

namespace Ticketing.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Client, UserType.Staff })]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string authorization)
        {
            var products = await _productService.Get();
            if (products == null)
            {
                return Ok(new List<ProductViewResult>());
            }

            return Ok(products);
        }

        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPost("create")]
        public async Task<ActionResult> Post(string authorization, ProductCreateParameters parameters)
        {

            var product = await _productService.Create(parameters);
            if (product == null)
            {
                return Ok(new ProductCreateResult());
            }
            return Ok(product);

        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpPut("update")]
        public async Task<ActionResult> Put(string authorization, int id, ProductUpdateParameters parameters)
        {

            var product = await _productService.Update(id, parameters);
            if (product == null)
            {
                return Ok(new ProductUpdateResult());
            }
            return Ok(product);
        }
        [Authorize(Rules = new[] { UserType.Manager })]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string authorization, int id)
        {
            var result = await _productService.Delete(id);
            if (result == 0)
            {
                return Ok(new int());
            }
            return Ok(result);
        }
    }
}
