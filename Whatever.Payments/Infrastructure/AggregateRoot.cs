namespace Whatever.Payments.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public abstract class AggregateRoot
    {
        private readonly List<IEvent> changes = new List<IEvent>();
        private readonly Dictionary<Type, Action<IEvent>> handlers = new Dictionary<Type, Action<IEvent>>();

        public Guid Id { get; protected set; }

        public void Emit(IEvent evt)
        {
            ApplyChange(evt, true);
        }

        public void LoadFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var evt in history)
            {
                ApplyChange(evt, false);
            }
        }

        public IEnumerable<IEvent> UncommitedChanges => changes.AsReadOnly();

        public void MarkChangesAsCommitted()
        {
            changes.Clear();
        }

        protected void RegisterHandler<T>(Action<T> handler) where T : IEvent
        {
            handlers.Add(typeof(T), evt => handler.Invoke((T)evt));
        }

        private void ApplyChange(IEvent evt, bool isNew)
        {
            var eventType = evt.GetType();

            if (!handlers.ContainsKey(eventType))
            {
                throw new InvalidOperationException($"Handler not registerd for {eventType}");
            }

            var handler = handlers[eventType];
            handler.Invoke(evt);
            if (isNew) changes.Add(evt);
        }
    }
}
