using System;


namespace HyperEdge.Shared.Protocol.Models
{
    public class PackageDTO
    {
        public Ulid Id { get; set; }
        public Ulid StoreId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

