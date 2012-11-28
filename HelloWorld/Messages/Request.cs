using NServiceBus;

namespace Messages
{
    public class Request : IMessage
    {
        public WireEncryptedString SaySomething { get; set; }
    }
}
