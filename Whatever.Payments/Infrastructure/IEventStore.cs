using System;
using System.Collections.Generic;

namespace Whatever.Payments
{
    public interface IEventStore
    {
        IEnumerable<IEvent> GetLog<T>(Guid aggregateId) where T : AggregateRoot;
        void Store<T>(Guid aggregateId, IEvent evt) where T : AggregateRoot;
    }
}