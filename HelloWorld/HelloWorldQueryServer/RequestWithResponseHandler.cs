using Messages;
using NServiceBus;

namespace HelloWorldQueryServer
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