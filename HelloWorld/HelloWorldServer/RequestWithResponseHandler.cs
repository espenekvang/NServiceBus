using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    public class RequestWithResponseHandler : IHandleMessages<RequestWithResponse>
    {
        public IBus Bus { get; set; }

        public void Handle(RequestWithResponse message)
        {
            Bus.Return(message.SaySomething.Value.Length%2);
        }
    }
}