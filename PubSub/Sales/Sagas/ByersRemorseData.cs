using System;
using NServiceBus.Saga;

namespace Sales.Sagas
{
    public class ByersRemorseData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        [Unique]
        public long OrderId { get; set; }
    }
}