using System;
using Whatever.Payments.Infrastructure;

namespace Whatever.Payments.Application
{
    public class AcceptPaymentRequestCommand : ICommand
    {
        public Guid PaymentRequestId { get; }

        public AcceptPaymentRequestCommand(Guid paymentRequestId)
        {
            PaymentRequestId = paymentRequestId;
        }
    }
}
