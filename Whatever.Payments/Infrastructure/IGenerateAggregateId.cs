using System;

namespace Whatever.Payments.Infrastructure
{
    public interface IGenerateAggregateId
    {
        Guid NewId();
    }
}
