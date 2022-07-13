//
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;

using HyperEdge.Backend.Db;


namespace HyperEdge.Backend.Db.Models
{

[MessagePack.MessagePackObject(true)]
[Table("user_models")]
public partial class UserModel : IModel<Ulid>
{
    [Key]
    public Ulid Id { get; set; } = Ulid.NewUlid();

    public Ulid AccountId { get; set; }

    [LeftJoin("accounts", "AccountId", "Id")]
    public AccountModel Account { get; set; }

    [NotMapped]
    public Dictionary<string, Dictionary<int, ulong>> Inventory { get; set; }
}

}