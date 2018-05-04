using System;

namespace Whatever.Payments.Infrastructure
{
    public class InMemoryRepository : IRepository
    {
        private IEventStore store;

        public InMemoryRepository(IEventStore store)
        {
            this.store = store;
        }

        public void Save<T>(T aggregate) where T : AggregateRoot
        {
            foreach (var evt in aggregate.UncommitedChanges)
            {
                store.Store<T>(aggregate.Id, evt);
            }
            
            aggregate.MarkChangesAsCommitted();
        }

        public T Load<T>(Guid aggregateId) where T : AggregateRoot, new()
        {
            var aggregate = new T();
            var log = store.GetLog<T>(aggregateId);
            aggregate.LoadFromHistory(log);

            return aggregate;
        }
    }
}
