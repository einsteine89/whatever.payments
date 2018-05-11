namespace Whatever.Payments.Infrastructure
{
    using System;

    public class EventStoreItem
    {
        public int Version { get; }
        public Type AggregateRootType { get; }
        public IEvent Event { get; }
        public Guid AggregateId { get; }

        public EventStoreItem(Type aggregateRootType, Guid aggregateId, int version, IEvent evt)
        {
            AggregateRootType = aggregateRootType;
            Version = version;
            Event = evt;
            AggregateId = aggregateId;
        }
    }
}
