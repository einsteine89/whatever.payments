﻿using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Whatever.Payments;
using Whatever.Payments.Application;
using Whatever.Payments.Domain.PaymentRequestDomain;
using Whatever.Payments.Infrastructure;

namespace Whatever.Tests
{
    [TestFixture]
    public class PaymentRequestTests
    {
        private IGenerateAggregateId idGenerator;
        private IRepository repository;

        [SetUp]
        public void SetUp()
        {
            idGenerator = Substitute.For<IGenerateAggregateId>();

            repository = new InMemoryRepository(new InMemoryEventStore());
        }

        [Test]
        public void Should_Work()
        {
            Guid aggregateId = Guid.NewGuid();
            idGenerator.NewId().Returns(aggregateId);

            var commandHanlder = new PaymentRequestCommandHandler(repository, idGenerator);
            commandHanlder.Handle(new CreatePaymentRequestCommand());
            commandHanlder.Handle(new AcceptPaymentRequestCommand(aggregateId));

            var pr = repository.Load<PaymentReqest>(aggregateId);
            pr.IsAccepted.Should().BeTrue();
        }

        [Test]
        public void Should_Work_With_Multiple_Instances_Of_The_Same_Aggregate()
        {
            var firstAggregateId = Guid.NewGuid();
            var secondAggregateId = Guid.NewGuid();
            idGenerator.NewId().Returns(firstAggregateId, secondAggregateId);

            var commandHanlder = new PaymentRequestCommandHandler(repository, idGenerator);
            commandHanlder.Handle(new CreatePaymentRequestCommand());
            commandHanlder.Handle(new CreatePaymentRequestCommand());
            commandHanlder.Handle(new AcceptPaymentRequestCommand(secondAggregateId));

            var firstPaymentRequest = repository.Load<PaymentReqest>(firstAggregateId);
            var secondPaymentRequest = repository.Load<PaymentReqest>(secondAggregateId);

            firstPaymentRequest.IsAccepted.Should().BeFalse();
            secondPaymentRequest.IsAccepted.Should().BeTrue();
        }
    }
}