using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.API.Proxies;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Parameters;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Staff.Web.Models;

namespace Ticketing.Staff.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductProxy _productProxy;

        public ProductController(IProductProxy productProxy)
        {
            _productProxy = productProxy;
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productProxy.Get();
            return View(new ProductCreateViewParameters { 
            Products = products,
            });
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            await _productProxy.Create(user.Token ,new ProductCreateParameters { 
            Name = parameters.Product.Name,
            TicketPriority = parameters.Product.TicketPriority
            });
            TempData["message"] = $"Product created successfully!.";

            return RedirectToAction("Index");
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpPost]
        public async Task<IActionResult> Update(ProductCreateViewParameters parameters)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            await _productProxy.Update(user.Token,parameters.Id,new ProductUpdateParameters
            {
                Name = parameters.Product.Name,
                TicketPriority = parameters.Product.TicketPriority
            });
            TempData["message"] = $"Product update successfully!.";
            return RedirectToAction("Index");
        }
        [Authorize(UserType = UserType.Manager)]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            await _productProxy.Delete(user.Token,id);
            return RedirectToAction("Index");
        }
    }
}
