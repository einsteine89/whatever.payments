using System;
using Whatever.Payments.Infrastructure;

namespace Whatever.Payments.Application.Commands
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
