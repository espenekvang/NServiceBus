using System;
using Events.Sales;
using NServiceBus.Testing;
using NUnit.Framework;
using Shipping.Sagas;

namespace Shipping.Tests.Handlers
{
    [TestFixture]
    public class OrderedPolicyTest
    {
        [Test]
        public void Handle_OrderAccepted_TimeoutFor10Seconds()
        {
            Test.Initialize();

            var orderAccepted = new OrderAccepted();
            Test.Saga<OrderPolicy>()
                .When(saga => saga.Handle(orderAccepted))
                .ExpectTimeoutToBeSetIn<OrderAccepted>((state, span)=> span == TimeSpan.FromSeconds(10));
        }
    }
}
