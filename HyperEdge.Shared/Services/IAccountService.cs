using MagicOnion;

using HyperEdge.Shared.Protocol;


namespace HyperEdge.Shared.Services
{
    public interface IAccountService : IService<IAccountService>
    {
        public UnaryResult<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest req);
        public UnaryResult<UpdateAccountResponse> UpdateAccount(UpdateAccountRequest req);
    }
}
