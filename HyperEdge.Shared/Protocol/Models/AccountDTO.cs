using System;
using MessagePack;


namespace HyperEdge.Shared.Protocol.Models
{
    [MessagePackObject(true)]
    public class AccountDTO
    {
        public Ulid Id { get; set; }

        public string DeviceUId { get; set; }

        public string Name { get; set; }
        
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string EKSHash { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
