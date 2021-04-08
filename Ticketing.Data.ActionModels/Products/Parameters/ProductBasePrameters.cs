using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Product.Parameters
{
    public abstract  class ProductBasePrameters
    {
        public string Name { get; set; }
        public TicketPriority TicketPriority { get; set; }


    }
}
