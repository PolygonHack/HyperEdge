using Microsoft.Extensions.Options;
using Quartz;

using HyperEdge.Backend.Db;


namespace HyperEdge.Backend.JobSystem
{ 
    public class QuartzOptionsConfigurator : IConfigureOptions<QuartzOptions>
    {
        private readonly DbConnectionOptions _dbOpts;

        public QuartzOptionsConfigurator(IOptions<DbConnectionOptions> dbOpts) 
        {
            this._dbOpts = dbOpts.Value;
        }

        public void Configure(QuartzOptions qOpts) 
        {
            qOpts["quartz.dataSource.default.connectionString"] = this._dbOpts.ConnectionString;
        } 
    }
}

