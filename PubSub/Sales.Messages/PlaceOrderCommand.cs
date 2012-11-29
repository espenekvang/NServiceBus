using NServiceBus;

namespace Sales.InternalMessages
{
    public class PlaceOrderCommand : ICommand
    {
        public long OrderId { get; set; }
    }
}
