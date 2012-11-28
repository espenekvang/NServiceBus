using Messages;
using NServiceBus;
using log4net;

namespace HelloWorldQueryServer
{
    public class RequestHandler : IHandleMessages<Request>
    {
        private readonly ISaySomething _saysSomething;

        public RequestHandler(ISaySomething saySomething)
        {
            _saysSomething = saySomething;
        }

        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething.Value);
            LogManager.GetLogger("RequestHandler").Info(_saysSomething.InResponseTo(message.SaySomething));
        }
    }
}