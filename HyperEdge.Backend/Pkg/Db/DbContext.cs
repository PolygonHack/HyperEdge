using Microsoft.Extensions.Options;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using MySql.Data.MySqlClient;

using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Db
{

public partial class DbContext : DapperDbContext, IDbContext
{
    private IDapperRepository<AccountModel> _account_models;
    public IDapperRepository<AccountModel> Accounts => _account_models ??
        (_account_models = new DapperRepository<AccountModel>(Connection, new SqlGenerator<AccountModel>(SqlProvider.MySQL)));

    public DbContext(IOptions<DbConnectionOptions> opts)
        : base(new MySqlConnection(opts.Value.ConnectionString))
    {
        //InitDb();
    }
}

}

