using NServiceBus;

namespace Shipping
{
    public class UpsResponse : IMessage
    {
        public long Order { get; set; }
    }
}