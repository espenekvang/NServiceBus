using NServiceBus;

namespace Shipping
{
    public class FedExResponse : IMessage
    {
        public long Order { get; set; }
    }
}