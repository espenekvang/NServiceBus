using System;
using CRM.Handlers;
using Events.Crm;
using Events.Sales;
using NServiceBus.Testing;
using NUnit.Framework;

namespace Crm.Tests.Handlers
{
    [TestFixture]
    public class OrderAcceptedHandlerTest
    {
        [Test]
        public void Handle_OrderIsAbove50000_CustomerStatusUpdatedPublished()
        {
            Test.Initialize();

            const int customerId = 1;
            Test.Handler<OrderAcceptedHandler>()
                .ExpectPublish<CustomerStatusUpdated>(
                    message => message.CustomerId == customerId && message.NewStatus == CustomerStatus.Preferred)
                .OnMessage<OrderAccepted>(orderAccepted => InitializeMessage(orderAccepted, 50001, customerId));
        }

        [Test]
        public void Handle_OrderIsBelow50000_CustomerStatusUpdatedNotPublished()
        {
            Test.Initialize();

            const int customerId = 2;
            Test.Handler<OrderAcceptedHandler>()
                .ExpectNotPublish<CustomerStatusUpdated>(message => message.CustomerId == customerId)
                .OnMessage<OrderAccepted>(orderAccepted => InitializeMessage(orderAccepted, 49999, customerId));
        }

        [Test]
        public void Handle_TwoOrdersWithSumExceeding50000_CustomerStatusUpdatedPublished()
        {
            Test.Initialize();

            const int customerId = 3;
            Test.Handler<OrderAcceptedHandler>()
                .ExpectNotPublish<CustomerStatusUpdated>(message => message.CustomerId == customerId)
                .OnMessage<OrderAccepted>(orderAccepted => InitializeMessage(orderAccepted, 25000, customerId));

            Test.Handler<OrderAcceptedHandler>()
                .ExpectPublish<CustomerStatusUpdated>(message => message.CustomerId == customerId)
                .OnMessage<OrderAccepted>(orderAccepted => InitializeMessage(orderAccepted, 25000, customerId));
        }

        private static void InitializeMessage(OrderAccepted orderAccepted, int orderValue, long customerId)
        {
            orderAccepted.CustomerId = customerId;
            orderAccepted.OrderValue = orderValue;
        }
    }
}
