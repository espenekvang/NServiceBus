using NServiceBus;

namespace Messages
{
    public class Query : IMessage
    {
        public int NumberOfResponses { get; set; }
    }
}