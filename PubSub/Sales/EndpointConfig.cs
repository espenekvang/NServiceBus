using System;
using NServiceBus;
using NServiceBus.Unicast;
using Sales.Commands;

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
	        var placeOrder = new PlaceOrder {OrderId = 1};
            Bus.SendLocal(placeOrder);

	      //  Console.ReadLine();

	        //var cancelOrder = new CancelOrder {OrderId = 1};
	        //Bus.SendLocal(cancelOrder);
	    }
    }
}