using System;
using Events.Sales;
using NServiceBus.Saga;

namespace Shipping.Sagas
{
    public class OrderPolicy : Saga<OrderPolicyData>,
        IAmStartedByMessages<OrderAccepted>,
        IHandleTimeouts<OrderAccepted>
    {
        public void Handle(OrderAccepted message)
        {
            Console.WriteLine("Wait in case the order is cancelled");
            RequestUtcTimeout<OrderAccepted>(TimeSpan.FromSeconds(10));
        }

        public void Timeout(OrderAccepted state)
        {
            
        }

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<OrderAccepted>(s => s.OrderId, m => m.OrderId);
        }
    }
}