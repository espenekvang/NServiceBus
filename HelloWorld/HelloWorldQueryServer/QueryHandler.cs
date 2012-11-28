using Messages;
using NServiceBus;

namespace HelloWorldQueryServer
{
    public class QueryHandler : IHandleMessages<Query>
    {
        public IBus Bus { get; set; }

        public void Handle(Query message)
        {
            for (int i = 0; i < message.NumberOfResponses; i++)
            {
                Bus.Reply<QueryResult>(m => m.Something = i.ToString());
            }
        }
    }
}
