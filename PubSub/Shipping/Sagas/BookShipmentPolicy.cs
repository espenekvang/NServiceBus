using System;
using NServiceBus;
using NServiceBus.Saga;
using Shipping.Messages;

namespace Shipping.Sagas
{
    public class BookShipmentPolicy : Saga<BookShipmentPolicyData>,
        IAmStartedByMessages<ShipOrder>, 
        IHandleTimeouts<FedExTimeout>,
        IHandleMessages<FedExResponse>,
        IHandleMessages<UpsResponse>
    {
        public void Handle(ShipOrder message)
        {
            Data.Order = message.Order;
            Bus.Send<ShipWithFedEx>(m => m.Order = message.Order);
            RequestUtcTimeout<FedExTimeout>(TimeSpan.FromSeconds(5));
        }

        public void Timeout(FedExTimeout state)
        {
            Bus.Send<ShipWithUps>(m => m.Order = Data.Order);
        }

        public void Handle(FedExResponse fedExResponse)
        {
            MarkAsComplete();
            ReplyToOriginator(new BookShipmentPolicyDone());
        }

        public void Handle(UpsResponse message)
        {
            MarkAsComplete();
            ReplyToOriginator(new BookShipmentPolicyDone());
        }
    }
}
