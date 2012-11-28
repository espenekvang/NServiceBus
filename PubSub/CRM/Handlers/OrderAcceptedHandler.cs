using System.Collections.Generic;
using Events.Crm;
using Events.Sales;
using NServiceBus;

namespace CRM.Handlers
{
    public class OrderAcceptedHandler : IHandleMessages<OrderAccepted>
    {
        private const int CustomerPreferredMinValue = 50000;
        private static readonly IDictionary<long, int> OrderValuePerCustomer = new Dictionary<long, int>(); 

        public IBus Bus { get; set; }

        public void Handle(OrderAccepted message)
        {
            UpdateOrderValuePerCustomer(message);

            if (!CustomerIsQualifiedForStatusUpdate(message.CustomerId)) return;
            
            var customerStatusUpdated = new CustomerStatusUpdated
                {
                    CustomerId = message.CustomerId,
                    NewStatus = CustomerStatus.Preferred
                };

            Bus.Publish(customerStatusUpdated);
        }

        private static bool CustomerIsQualifiedForStatusUpdate(long customerId)
        {
            int orderValue;
            OrderValuePerCustomer.TryGetValue(customerId, out orderValue);

            return orderValue >= CustomerPreferredMinValue;
        }

        private static void UpdateOrderValuePerCustomer(OrderAccepted orderAccepted)
        {
            int totalOrderValue;
            if (OrderValuePerCustomer.TryGetValue(orderAccepted.CustomerId, out totalOrderValue))
            {
                OrderValuePerCustomer.Remove(orderAccepted.CustomerId);
            }

            totalOrderValue += orderAccepted.OrderValue;

            OrderValuePerCustomer.Add(orderAccepted.CustomerId, totalOrderValue);
        }
    }
}
