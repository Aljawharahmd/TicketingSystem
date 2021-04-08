using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Statistic.Results
{
    public class TicketPerStatusResult
    {
        public TicketStatus Status { get; set; }
        public int Count { get; set; }
    }
}
