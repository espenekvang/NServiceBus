using NServiceBus;

namespace Events.Crm
{
    public class CustomerStatusUpdated : IEvent
    {
        public long CustomerId { get; set; }
        public CustomerStatus NewStatus { get; set; }
    }

    public enum CustomerStatus
    {
        NotPreferred,
        Preferred
    }
}