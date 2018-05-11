namespace Whatever.Payments.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using Whatever.Payments.Domain;

    public interface IEventStore
    {
        IEnumerable<IEvent> GetLog<T>(Guid aggregateId) where T : AggregateRoot;
        void Store<T>(Guid aggregateId, IEvent evt) where T : AggregateRoot;
    }
}