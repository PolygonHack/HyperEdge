using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using Nethereum.Hex.HexConvertors.Extensions;


namespace HyperEdge.Backend.Db.Models
{
    [Table("he_erc20_tokens")]
    public class Erc20TokenModel : IModel<Ulid>
    {

        [Key]
        public Ulid Id { get; set; }
        public Ulid OwnerId { get; set; }
        public byte[] Address { get; set; } = Array.Empty<byte>();
        [NotMapped]
        public string AddressHex { get => Address.ToHex(); }
        public string Name { get; set; } = string.Empty;        
        public string Symbol { get; set; } = string.Empty;        
        public string Data { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }       
        [UpdatedAt]
        public DateTime UpdatedAt { get; set; }
    }
}

