using Whatever.Payments.Domain.PaymentRequestDomain;
using Whatever.Payments.Infrastructure;

namespace Whatever.Payments.Application
{
    public class PaymentRequestCommandHandler : IHandlMessage<CreatePaymentRequestCommand>, IHandlMessage<AcceptPaymentRequestCommand>
    {
        private readonly IRepository repository;
        private readonly IGenerateAggregateId idGenerator;

        public PaymentRequestCommandHandler(IRepository repository, IGenerateAggregateId idGenerator)
        {
            this.repository = repository;
            this.idGenerator = idGenerator;
        }

        public void Handle(CreatePaymentRequestCommand cmd)
        {
            var paymentRequest = new PaymentReqest();
            paymentRequest.New(idGenerator.NewId(), cmd.Amount, cmd.CUI, cmd.SSN);
            repository.Save(paymentRequest);

        }

        public void Handle(AcceptPaymentRequestCommand cmd)
        {
            var paymentRequest = repository.Load<PaymentReqest>(cmd.PaymentRequestId);
            paymentRequest.Accept();
            repository.Save(paymentRequest);
        }
    }
}
