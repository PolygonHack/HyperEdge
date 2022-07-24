using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;


namespace HyperEdge.Backend.Db.Models
{
    [Table("he_packages")]
    public class PackageModel : IModel<Ulid>
    {
        [Key]
        public Ulid Id { get; set; }
        public Ulid StoreId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        [UpdatedAt]
        public DateTime UpdatedAt { get; set; }
    }
}

