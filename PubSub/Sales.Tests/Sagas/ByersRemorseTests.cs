using System;
using Events.Sales;
using NServiceBus.Testing;
using NUnit.Framework;
using Sales.Commands;
using Sales.Sagas;

namespace Sales.Tests.Sagas
{
    [TestFixture]
    public class ByersRemorseTests
    {
        [Test]
        public void Handle_PlaceOrderReceived_OrderReceivedPublished()
        {
            Test.Initialize();

            var placeOrder = new PlaceOrder{OrderId = 1};
            Test.Saga<ByersRemorse>()
                .ExpectPublish<OrderReceived>(orderReceived => orderReceived.OrderId == 1)
                .When(saga => saga.Handle(placeOrder));
        }

        [Test]
        public void Handle_PlaceOrderReceived_TimeoutShouldBeSet()
        {
            Test.Initialize();

            var placeOrder = new PlaceOrder { OrderId = 1 };
            Test.Saga<ByersRemorse>()
                .ExpectTimeoutToBeSetIn<PlaceOrder>((state, span)=> span == TimeSpan.FromSeconds(10))
                .When(saga => saga.Handle(placeOrder));
        }

        [Test]
        public void Handle_TimeoutReachedForOrderReceived_OrderAcceptedPublished()
        {
            Test.Initialize();

            var state = new PlaceOrder{OrderId = 1};
            Test.Saga<ByersRemorse>()
                .ExpectPublish<OrderAccepted>(m => m.OrderId == 1)
                .When(saga => saga.Timeout(state));
        }

        /*[Test]
        public void Handle_CancelOrderedReceived_OrderedCa()
        {
            Test.Initialize();

            var state = new PlaceOrder { OrderId = 1 };
            Test.Saga<ByersRemorse>()
                .When(saga => saga.Timeout(state))
                .AssertSagaCompletionIs(true);
        }*/
    }
}
