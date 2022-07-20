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
        private IDapperRepository<StoreModel> _store_models;
        private IDapperRepository<PackageModel> _package_models;
        private IDapperRepository<Erc20TokenModel> _erc20_models;
        private IDapperRepository<Erc1155TokenModel> _erc1155_models;


        public IDapperRepository<AccountModel> Accounts => _account_models ??
            (_account_models = new DapperRepository<AccountModel>(Connection, new SqlGenerator<AccountModel>(SqlProvider.MySQL)));


        public IDapperRepository<StoreModel> Stores => _store_models ??
            (_store_models = new DapperRepository<StoreModel>(
                Connection, new SqlGenerator<StoreModel>(SqlProvider.MySQL)));
    
        public IDapperRepository<PackageModel> Packages => _package_models ??
            (_package_models = new DapperRepository<PackageModel>(
                Connection, new SqlGenerator<PackageModel>(SqlProvider.MySQL)));

        public IDapperRepository<Erc20TokenModel> Erc20Tokens => _erc20_models ??
            (_erc20_models = new DapperRepository<Erc20TokenModel>(
                Connection, new SqlGenerator<Erc20TokenModel>(SqlProvider.MySQL)));

        public IDapperRepository<Erc1155TokenModel> Erc1155Tokens => _erc1155_models ??
            (_erc1155_models = new DapperRepository<Erc1155TokenModel>(
                Connection, new SqlGenerator<Erc1155TokenModel>(SqlProvider.MySQL)));


        public DbContext(IOptions<DbConnectionOptions> opts)
            : base(new MySqlConnection(opts.Value.ConnectionString))
        {
            //InitDb();
        }
    }
}
