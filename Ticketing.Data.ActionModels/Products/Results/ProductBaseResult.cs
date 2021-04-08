using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Product.Results
{
    public abstract  class ProductBaseResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TicketPriority TicketPriority { get; set; }

        
    }
}
