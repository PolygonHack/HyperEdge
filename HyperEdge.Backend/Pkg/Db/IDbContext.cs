//
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;

using HyperEdge.Backend.Db.Models;

namespace HyperEdge.Backend.Db
{

public partial interface IDbContext : IDapperDbContext
{
    IDapperRepository<AccountModel> Accounts { get; }
}

}
