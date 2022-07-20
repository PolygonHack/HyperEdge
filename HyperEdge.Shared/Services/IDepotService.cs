using MagicOnion;

using HyperEdge.Shared.Protocol;


namespace HyperEdge.Shared.Services
{
    public interface IDepotService : IService<IDepotService>
    {
        /* ERC-20 token API */
        public UnaryResult<CreateErc20TokenResponse> CreateErc20Token(CreateErc20TokenRequest req);

        /* ERC-1155 API */
        public UnaryResult<CreateErc1155TokenResponse> CreateErc1155Token(CreateErc1155TokenRequest req);

        /* Stores API */
        public UnaryResult<GetStoreResponse> GetStore(GetStoreRequest req);
        public UnaryResult<CreateStoreResponse> CreateStore(CreateStoreRequest req);
        public UnaryResult<UpdateStoreResponse> UpdateStore(UpdateStoreRequest req);

        /* Packages API */
        public UnaryResult<CreatePackageResponse> CreatePackage(CreatePackageRequest req);
        public UnaryResult<UpdatePackageResponse> UpdatePackage(UpdatePackageRequest req);
        public UnaryResult<GetPackageResponse> GetPackage(GetPackageRequest req);
    }
}
