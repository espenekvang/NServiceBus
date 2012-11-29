using NServiceBus;

namespace Events.Sales
{
    public class OrderReceived : IEvent
    {
        public long OrderId { get; set; }
    }
}