using NServiceBus;

namespace Sales.Commands
{
    public class PlaceOrder : ICommand
    {
        public long OrderId { get; set; }
    }
}
