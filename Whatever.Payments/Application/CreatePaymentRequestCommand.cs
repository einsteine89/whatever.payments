﻿using Whatever.Payments.Infrastructure;

namespace Whatever.Payments.Application
{
    public class CreatePaymentRequestCommand : ICommand
    {
        public string SSN { get; set; }

        public string CUI { get; set; }

        public decimal Amount { get; set; }
    }
}
