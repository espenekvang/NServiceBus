using System;
using NServiceBus.Testing;
using NUnit.Framework;
using Shipping.Messages;
using Shipping.Sagas;

namespace Shipping.Tests
{
    [TestFixture]
    public class BookShipmentPolicyTest
    {
        [Test]
        public void Handle_ShipOrderArrived_SendToFedEx()
        {
            Test.Initialize();

            var shipOrder = new ShipOrder {Order = 1};
            Test.Saga<BookShipmentPolicy>()
                .ExpectSend<ShipWithFedEx>(m => m.Order == shipOrder.Order)
                .When(saga => saga.Handle(shipOrder));
        }

        [Test]
        public void Handle_ShipOrderArrived_TimeoutShouldBeSet()
        {
            Test.Initialize();

            var shipOrder = new ShipOrder{Order = 1};
            Test.Saga<BookShipmentPolicy>()
                .ExpectTimeoutToBeSetIn<FedExTimeout>((state,span) => span == TimeSpan.FromSeconds(5))
                .When(saga => saga.Handle(shipOrder));
        }

        [Test]
        public void Handle_FedExTimesOut_SendToUps()
        {
            Test.Initialize();

            var fedExTimeout = new FedExTimeout();
            var shipOrder = new ShipOrder {Order = 1};
            Test.Saga<BookShipmentPolicy>()
                .When(policy => policy.Handle(shipOrder))
                .ExpectSend<ShipWithUps>(m => m.Order == shipOrder.Order)
                .When(saga => saga.Timeout(fedExTimeout));
        }

        [Test]
        public void Handle_FedExResponseArrived_MarkAsCompleteCalled()
        {
            Test.Initialize();

            var fedExResponse = new FedExResponse();
            Test.Saga<BookShipmentPolicy>()
                .When(saga => saga.Handle(fedExResponse))
                .AssertSagaCompletionIs(true);
        }

        [Test]
        public void Handle_UpsResponseArrived_MarkAsCompleteCalled()
        {
            Test.Initialize();

            var fedExResponse = new UpsResponse();
            Test.Saga<BookShipmentPolicy>()
                .When(saga => saga.Handle(fedExResponse))
                .AssertSagaCompletionIs(true);
        }

        [Test]
        public void Handle_FedExResponseArrived_ReplyToOriginatorCalled()
        {
            Test.Initialize();

            var fedExResponse = new FedExResponse();
            Test.Saga<BookShipmentPolicy>()
                .When(saga => saga.Handle(fedExResponse))
                .ExpectReplyToOrginator<BookShipmentPolicyDone>();
        }

        [Test]
        public void Handle_UpsResponseArrived_ReplyToOriginatorCalled()
        {
            Test.Initialize();

            var fedExResponse = new UpsResponse();
            Test.Saga<BookShipmentPolicy>()
                .When(saga => saga.Handle(fedExResponse))
                .ExpectReplyToOrginator<BookShipmentPolicyDone>();
        }
    }
}
