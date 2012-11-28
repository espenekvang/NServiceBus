using Messages;
using NServiceBus;

namespace MvcApplication1.Handlers
{
    public class QueryResultHandler : IHandleMessages<QueryResult>
    {
        public void Handle(QueryResult message)
        {
            message.ToString();
        }
    }
}