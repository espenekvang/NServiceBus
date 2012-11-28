using NServiceBus;
using log4net;

namespace HelloWorldQueryServer
{
    public class Auth : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
            if (!Authorized(message.GetHeader("user")))
            {
                LogManager.GetLogger("Auth").Warn("User not authorized.");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            }
            else
            {
                LogManager.GetLogger("Auth").Info("User authorized");
            }
        }

        private bool Authorized(string user)
        {
            return user == "udi";
        }
    }
}
