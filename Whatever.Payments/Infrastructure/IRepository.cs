using System;

namespace Whatever.Payments.Infrastructure
{
    using Whatever.Payments.Domain;

    public interface IRepository
    {
        T Load<T>(Guid aggregateId) where T : AggregateRoot, new();
        void Save<T>(T aggregate) where T : AggregateRoot;
    }
}