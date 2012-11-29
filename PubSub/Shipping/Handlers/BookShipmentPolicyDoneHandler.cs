using System;
using NServiceBus;
using Shipping.Messages;

namespace Shipping.Handlers
{
    public class BookShipmentPolicyDoneHandler : IHandleMessages<BookShipmentPolicyDone>
    {
        public void Handle(BookShipmentPolicyDone message)
        {
            Console.WriteLine("All done with shipment booking");
        }
    }
}
