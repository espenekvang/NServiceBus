using NServiceBus;

namespace Shipping.Messages
{
    public class ShipWithUps : IMessage
    {
        public long Order { get; set; }
    }
}