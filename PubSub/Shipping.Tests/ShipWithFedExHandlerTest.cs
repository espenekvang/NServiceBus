using NServiceBus.Testing;
using NUnit.Framework;
using Shipping.Handlers;
using Shipping.Messages;

namespace Shipping.Tests
{
    [TestFixture]
    public class ShipWithFedExHandlerTest
    {
        [Test]
        public void Handle_MessageReceived_ReplyCalled()
        {
            Test.Initialize();

             Test.Handler<ShipWithFedExHandler>()
                 .ExpectReply<FedExResponse>(r=>r.Order == 1)
                 .OnMessage<ShipWithFedEx>(m=>m.Order = 1);
        }
    }
}
