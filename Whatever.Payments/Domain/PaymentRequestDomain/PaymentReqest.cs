using System;
using Whatever.Payments.Domain.PaymentRequestDomain.Events;

namespace Whatever.Payments.Domain.PaymentRequestDomain
{
    public class PaymentReqest : AggregateRoot
    {
        public PaymentReqest()
        {
            RegisterHandler<PaymentRequestCreated>(Apply);
            RegisterHandler<PaymentRequestAccepted>(Apply);
        }

        public bool IsAccepted { get; private set; }

        public void New(Guid paymentRequestId, decimal amount, string cui, string ssn)
        {
            var evt = new PaymentRequestCreated
            {
                PaymentRequestId = paymentRequestId,
                Amount = amount,
                CUI = cui,
                SSN = ssn
            };

            Emit(evt);
        }

        public void Accept()
        {
            var evt = new PaymentRequestAccepted { PaymentRequestId = Id };

            Emit(evt);
        }

        public void Apply(PaymentRequestCreated evt)
        {
            Id = evt.PaymentRequestId;
        }

        public void Apply(PaymentRequestAccepted evt)
        {
            IsAccepted = true;
        }
    }
}
