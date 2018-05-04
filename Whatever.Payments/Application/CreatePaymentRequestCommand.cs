namespace Whatever.Payments.Application
{
    public class CreatePaymentRequestCommand
    {
        public string SSN { get; set; }

        public string CUI { get; set; }

        public decimal Amount { get; set; }
    }
}
