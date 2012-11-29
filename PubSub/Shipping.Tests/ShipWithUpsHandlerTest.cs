using NServiceBus.Testing;
using NUnit.Framework;
using Shipping.Handlers;
using Shipping.Messages;

namespace Shipping.Tests
{
    [TestFixture]
    public class ShipWithUpsHandlerTest
    {
        [Test]
        public void Handle_MessageReceived_ReplyCalled()
        {
            Test.Initialize();

             Test.Handler<ShipWithUpsHandler>()
                 .ExpectReply<UpsResponse>(r=>r.Order == 1)
                 .OnMessage<ShipWithUps>(m=>m.Order = 1);
        }
    }
}
