using System;
using Events.Sales;
using NServiceBus;
using NServiceBus.Saga;
using Sales.Commands;

namespace Sales.Sagas
{
    public class ByersRemorse : Saga<ByersRemorseData>,
        IAmStartedByMessages<PlaceOrder>,
        IHandleTimeouts<PlaceOrder>,
        IHandleMessages<OrderReceived>,
        IHandleMessages<CancelOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Data.OrderId = message.OrderId;
            Bus.Publish<OrderReceived>(e => e.OrderId = message.OrderId);
        }

        public void Timeout(PlaceOrder state)
        {
            Bus.Publish<OrderAccepted>(oa => oa.OrderId = state.OrderId);
        }

        public void Handle(CancelOrder message)
        {
            
        }

        public void Handle(OrderReceived message)
        {
            RequestUtcTimeout<PlaceOrder>(TimeSpan.FromSeconds(10));
        }
    }
}