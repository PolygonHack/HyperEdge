using HyperEdge.Backend.Db.Models;
using HyperEdge.Backend.Repositories;


namespace HyperEdge.Backend.Services
{  
    public class CurrentUserService : ICurrentUserService
    {
        private UserModel _user;
        public UserModel User { get => _user; }

        private readonly IUserRepository _userRepo;
        public CurrentUserService(IUserRepository userRepo)
        {
            this._userRepo = userRepo;
        }

        public async Task<UserModel> LoadAsync(Ulid userId)
        {
            _user = await _userRepo.GetAsync(userId);
            return _user;
        }
    }
}
