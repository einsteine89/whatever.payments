using System;

namespace Whatever.Payments.Domain.PaymentRequestDomain.Events
{
    public class PaymentRequestAccepted : IEvent
    {
        public Guid PaymentRequestId { get; set; }
    }
}
