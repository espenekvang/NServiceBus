using System.Threading;
using NServiceBus;
using Shipping.Messages;

namespace Shipping.Handlers
{
    public class ShipWithFedExHandler : IHandleMessages<ShipWithFedEx>
    {
        public IBus Bus { get; set; }

        public void Handle(ShipWithFedEx message)
        {
            //Bus.Reply<FedExResponse>(response => response.Order = message.Order);
        }
    }
}
