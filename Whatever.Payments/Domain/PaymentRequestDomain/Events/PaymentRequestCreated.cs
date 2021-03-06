﻿using System;

namespace Whatever.Payments.Domain.PaymentRequestDomain.Events
{
    using Whatever.Payments.Infrastructure;

    public class PaymentRequestCreated : IEvent
    {
        public Guid PaymentRequestId { get; set; }

        public string SSN { get; set; }

        public string CUI { get; set; }

        public decimal Amount { get; set; }
    }
}
