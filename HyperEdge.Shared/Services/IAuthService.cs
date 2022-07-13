using MagicOnion;

using HyperEdge.Shared.Protocol;


namespace HyperEdge.Shared.Services
{
    public interface IAuthService : IService<IAuthService>
    {
        public UnaryResult<GetChallengeResponse> GetChallengeAsync(GetChallengeRequest req);
        public UnaryResult<ValidateChallengeResponse> ValidateAsync(ValidateChallengeRequest req);
    }
}
