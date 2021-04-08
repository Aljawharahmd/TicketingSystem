using System;

namespace Ticketing.Trace.Abstraction
{
    public interface IRequestTrace
    {
        Guid Id { get; }
        DateTime TimeStamp { get; }

        void Register(Guid id);
    }

}
