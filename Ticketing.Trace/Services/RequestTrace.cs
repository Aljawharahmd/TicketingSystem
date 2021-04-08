using System;
using Ticketing.Trace.Abstraction;

namespace Ticketing.Trace.Services
{
    public class RequestTrace : IRequestTrace
    {
        public Guid Id { get; protected set; }

        public DateTime TimeStamp { get; protected set; }

        public RequestTrace()
        {
            TimeStamp = DateTime.Now;
        }
        public void Register(Guid id)
        {
            Id = id;
        }
    }

}
