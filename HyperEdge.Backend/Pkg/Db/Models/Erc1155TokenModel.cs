using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using Nethereum.Hex.HexConvertors.Extensions;


namespace HyperEdge.Backend.Db.Models
{
    [Table("Erc1155Tokens")]
    public class Erc1155TokenModel : IModel<Ulid>
    {
        [Key]
        public Ulid Id { get; set; }
        public byte[] Address { get; set; } = Array.Empty<byte>();
        [NotMapped]
        public string AddressHex { get => Address.ToHex(); }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        [UpdatedAt]
        public DateTime UpdatedAt { get; set; }
    }
}
