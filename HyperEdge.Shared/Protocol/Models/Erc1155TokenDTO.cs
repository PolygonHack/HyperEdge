using System;


namespace HyperEdge.Shared.Protocol.Models
{
    public class Erc1155TokenDTO
    {
        public Ulid Id { get; set; }
        public byte[] Address { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

