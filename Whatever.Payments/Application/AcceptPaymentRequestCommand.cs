using System;

namespace Whatever.Payments.Application
{
    public class AcceptPaymentRequestCommand
    {
        public Guid PaymentRequestId { get; }

        public AcceptPaymentRequestCommand(Guid paymentRequestId)
        {
            PaymentRequestId = paymentRequestId;
        }
    }
}
