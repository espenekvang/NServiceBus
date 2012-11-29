using NServiceBus;

namespace Events.Sales
{
    public class OrderAccepted : IEvent
    {
        public long CustomerId { get; set; }
        public long OrderId { get; set; }
        public int OrderValue { get; set; }
    }
}
