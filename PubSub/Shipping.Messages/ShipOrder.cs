using NServiceBus;

namespace Shipping.Messages
{
    public class ShipOrder : IMessage
    {
        public long Order { get; set; }
    }
}