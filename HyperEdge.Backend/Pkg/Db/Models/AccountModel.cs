using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using Nethereum.Hex.HexConvertors.Extensions;


namespace HyperEdge.Backend.Db.Models
{
    [Table("accounts")]
    public class AccountModel
    {
        public Ulid Id { get; set; } = Ulid.NewUlid();

        public string DeviceUId { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public byte[] Address { get; set; } = Array.Empty<byte>();

        [NotMapped]
        public string AddressHex { get => Address.ToHex(); }

        public string EKS { get; set; } = string.Empty;
        public string EKSHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 
