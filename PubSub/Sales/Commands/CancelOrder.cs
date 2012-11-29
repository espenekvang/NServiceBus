using NServiceBus;

namespace Sales.Commands
{
    public class CancelOrder : ICommand
    {
        public long OrderId { get; set; }
    }
}