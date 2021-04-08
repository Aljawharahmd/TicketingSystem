using System.Collections.Generic;
using Ticketing.Data.ActionModels.Parameters;
using Ticketing.Data.ActionModels.Product.Results;

namespace Ticketing.Staff.Web.Models
{
    public class ProductCreateViewParameters
    {
        public List<ProductViewResult> Products { get; set; }
        public ProductCreateParameters Product { get; set; }
        public int Id { get; set; }
    }
}
