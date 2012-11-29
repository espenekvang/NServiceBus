using NServiceBus;
using Shipping.Messages;

namespace Shipping.Handlers
{
    public class ShipWithUpsHandler : IHandleMessages<ShipWithUps>
    {
        public IBus Bus { get; set; }

        public void Handle(ShipWithUps message)
        {
            Bus.Reply<UpsResponse>(r => r.Order = message.Order);
        }
    }
}
