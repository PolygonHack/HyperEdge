using System;
using System.Runtime.Serialization;
using MessagePack;


namespace HyperEdge.Shared.Protocol.Models
{
    [MessagePackObject(true)]
    public class StoreDTO
    {
        public Ulid Id { get; set; }
        public Ulid MerchantId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

