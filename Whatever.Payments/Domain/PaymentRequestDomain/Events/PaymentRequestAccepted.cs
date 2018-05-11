using System;

namespace Whatever.Payments.Domain.PaymentRequestDomain.Events
{
    using Whatever.Payments.Infrastructure;

    public class PaymentRequestAccepted : IEvent
    {
        public Guid PaymentRequestId { get; set; }
    }
}
