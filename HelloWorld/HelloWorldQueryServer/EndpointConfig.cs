using NServiceBus;

namespace HelloWorldQueryServer
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            Configure.With()
                     .DefaultBuilder()
                     .XmlSerializer("http://acme.com/")
                     .RunCustomAction(() =>
                                      Configure.Instance
                                               .Configurer
                                               .ConfigureComponent
                                          <SaySomething>(DependencyLifecycle.SingleInstance))
                                          .RijndaelEncryptionService();
        }

        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}
