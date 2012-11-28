using System;
using Events.Crm;
using NServiceBus;

namespace Sales.Handlers
{
    public class CustomerStatusUpdatedHandler : IHandleMessages<CustomerStatusUpdated>
    {
        public void Handle(CustomerStatusUpdated message)
        {
            Console.WriteLine(string.Format("Customer with id {0} has been updated with status {1}", message.CustomerId, message.NewStatus));
        }
    }
}
