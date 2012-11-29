using NServiceBus;

namespace Shipping.Messages
{
    public class ShipWithFedEx : IMessage
    {
        public long Order { get; set; }
    }
}