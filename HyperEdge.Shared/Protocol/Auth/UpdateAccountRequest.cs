using System;
using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class UpdateAccountRequest
    {
        public Ulid Id { get; set; }

        public string Name { get; set; }        
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Phone { get; set; }

        public byte[] Address { get; set; }

        public string EKS { get; set; }
    }
}

