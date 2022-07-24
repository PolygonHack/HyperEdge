using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;


namespace HyperEdge.Backend.Db.Models
{
    [Table("he_stores")]
    public class StoreModel : IModel<Ulid>
    {
        [Key]
        public Ulid Id { get; set; }
        public Ulid MerchantId { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

