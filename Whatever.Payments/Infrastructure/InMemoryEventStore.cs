namespace Whatever.Payments.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Whatever.Payments.Domain;

    public class InMemoryEventStore : IEventStore
    {
        private static object _lock = new object();

        private int version = 0;
        private List<EventStoreItem> log = new List<EventStoreItem>();

        public IEnumerable<IEvent> GetLog<T>(Guid aggregateId) where T : AggregateRoot
        {
            return log.Where(x => x.AggregateRootType == typeof(T) && x.AggregateId == aggregateId).OrderBy(x => x.Version).Select(x => x.Event);
        }

        public void Store<T>(Guid aggregateId, IEvent evt) where T : AggregateRoot
        {
            var item = new EventStoreItem(typeof(T), aggregateId, ++version, evt);
            log.Add(item);
        }
    }
}
