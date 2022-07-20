//
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;

using HyperEdge.Backend.Db.Models;

namespace HyperEdge.Backend.Db
{

    public partial interface IDbContext : IDapperDbContext
    {
        IDapperRepository<AccountModel> Accounts { get; }
        IDapperRepository<StoreModel> Stores { get; }
        IDapperRepository<PackageModel> Packages { get; }
        IDapperRepository<Erc20TokenModel> Erc20Tokens { get; }
        IDapperRepository<Erc1155TokenModel> Erc1155Tokens { get; }
    }
}
