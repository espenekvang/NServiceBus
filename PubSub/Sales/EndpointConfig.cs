using Events;
using Events.Sales;
using NServiceBus;
using NServiceBus.Unicast;

namespace Sales 
{
	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://nservicebus.com/GenericHost.aspx
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantToRunWhenTheBusStarts
    {
        public IBus Bus { get; set; }

        public void Init()
        {
            

        }

	    public void Run()
	    {
	        var orderAccepted = new OrderAccepted {CustomerId = 1, OrderValue = 10000};

	        for (int i = 0; i < 10; i++)
	        {
                Bus.Publish(orderAccepted);    
	        }
	        
	    }
    }
}