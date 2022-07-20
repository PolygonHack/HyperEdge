using AutoMapper;

using HyperEdge.Backend.Db.Models;
using HyperEdge.Shared.Protocol;
using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Backend.Mappings
{
    public partial class AutoMapping : Profile
    {
        public AutoMapping()
        {
//            CreateMap<AccountModel, RegisterAccountRequest>().ReverseMap();
//            CreateMap<AccountModel, AccountDTO>().ReverseMap();
//            CreateMap<UpdateAccountRequest, AccountModel>();
//            CreateGeneratedMappings();
            CreateMap<StoreModel, StoreDTO>().ReverseMap();
            CreateMap<PackageModel, PackageDTO>().ReverseMap();

            CreateMap<CreateErc20TokenRequest, Erc1155TokenModel>().ReverseMap();
            CreateMap<Erc20TokenModel, Erc20TokenDTO>().ReverseMap();

            CreateMap<CreateErc1155TokenRequest, Erc1155TokenModel>().ReverseMap();
            CreateMap<Erc1155TokenModel, Erc1155TokenDTO>().ReverseMap();
        }
    }
}
