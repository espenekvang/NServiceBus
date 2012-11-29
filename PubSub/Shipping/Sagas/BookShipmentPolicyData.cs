using System;
using NServiceBus.Saga;

namespace Shipping.Sagas
{
    public class BookShipmentPolicyData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        
        public long Order { get; set; }
    }
}