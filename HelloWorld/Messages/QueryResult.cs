using NServiceBus;

namespace Messages
{
    public class QueryResult : IMessage
    {
        public string Something { get; set; }
    }
}