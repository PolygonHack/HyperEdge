using AutoMapper;
using MagicOnion;
using MagicOnion.Server;
using Microsoft.Extensions.Logging;
using Quartz;

using HyperEdge.Backend.Db;
using HyperEdge.Backend.Db.Models;
using HyperEdge.Shared.Services;
using HyperEdge.Shared.Protocol;
using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Backend.Services
{
    public partial class DepotService : ServiceBase<IDepotService>, IDepotService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _db;
        public IDbContext Db { get => _db; }

        //private readonly ISchedulerFactory _schedFactory;
        private readonly ILogger<DepotService> _logger;

        public DepotService(
            IMapper mapper,
            IDbContext db,
            //ISchedulerFactory schedFactory,
            ILogger<DepotService> logger)
        {
            this._mapper = mapper;
            this._db = db;
            //this._schedFactory = schedFactory;
            this._logger = logger;
        }

        public async UnaryResult<CreatePackageResponse> CreatePackage(CreatePackageRequest req)
        {
            var pModel = new PackageModel();
            this._mapper.Map(req.Package, pModel);
            await this.Db.Packages.InsertAsync(pModel);
            var pDto = this._mapper.Map<PackageDTO>(pModel);
            return new CreatePackageResponse { Package = pDto };
        }
        
        public async UnaryResult<UpdatePackageResponse> UpdatePackage(UpdatePackageRequest req)
        {
            var pModel = await this.Db.Packages.FindByIdAsync(req.PackageId);
            var pDto = this._mapper.Map<PackageDTO>(pModel);
            return new UpdatePackageResponse { Package = pDto };
        }
        
        public async UnaryResult<GetPackageResponse> GetPackage(GetPackageRequest req)
        {
            var pModel = await this.Db.Packages.FindByIdAsync(req.PackageId);
            var pDto = this._mapper.Map<PackageDTO>(pModel);
            return new GetPackageResponse { Package = pDto };
        }

        public async UnaryResult<GetStoreResponse> GetStore(GetStoreRequest req)
        {
            var sModel = await this.Db.Stores.FindByIdAsync(req.StoreId);
            if (sModel is null)
            {
                throw new ReturnStatusException((Grpc.Core.StatusCode)99, "Store not found");
            }
            var sDto = this._mapper.Map<StoreDTO>(sModel);
            return new GetStoreResponse { Store = sDto };
        }

        public async UnaryResult<CreateStoreResponse> CreateStore(CreateStoreRequest req)
        {

            var sModel = new StoreModel();
            this._mapper.Map(req, sModel);
            sModel.Id = Ulid.NewUlid();
            sModel.MerchantId = Ulid.NewUlid(); 
            Console.WriteLine($"{sModel.Id.ToString()}");
            await this.Db.Stores.InsertAsync(sModel);
            var sDto = this._mapper.Map<StoreDTO>(sModel);
            return new CreateStoreResponse { Store = sDto };
        }

        public async UnaryResult<UpdateStoreResponse> UpdateStore(UpdateStoreRequest req)
        {
            var sModel = await this.Db.Stores.FindByIdAsync(req.StoreId); 
            // FIXME
            var sDto = this._mapper.Map<StoreDTO>(sModel);
            return new UpdateStoreResponse { Store = sDto };
        }

        public async UnaryResult<CreateErc20TokenResponse> CreateErc20Token(CreateErc20TokenRequest req)
        {
            var tModel = new Erc20TokenModel();
            this._mapper.Map(req, tModel);
            tModel.Id = Ulid.NewUlid();

            await this.Db.Erc20Tokens.InsertAsync(tModel);
            //var sched = await _schedFactory.GetScheduler();    
            //await sched.TriggerJob(new JobKey("DeployErc20Token"));
            var tDto = this._mapper.Map<Erc20TokenDTO>(tModel);
            return new CreateErc20TokenResponse { Erc20Token = tDto };
        }

        public async UnaryResult<CreateErc1155TokenResponse> CreateErc1155Token(CreateErc1155TokenRequest req)
        {
            var tModel = new Erc1155TokenModel();
            this._mapper.Map(req, tModel);
            tModel.Id = Ulid.NewUlid();

            await this.Db.Erc1155Tokens.InsertAsync(tModel);
            //var sched = await _schedFactory.GetScheduler();
            //await sched.TriggerJob(new JobKey("DeployErc1155Token"));
            var tDto = this._mapper.Map<Erc1155TokenDTO>(tModel);
            return new CreateErc1155TokenResponse { Erc1155Token = tDto };
        }
    }
}
