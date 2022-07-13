using System;
using System.Text;
using System.Security.Cryptography;
using AutoMapper; 
using MagicOnion;
using MagicOnion.Server;

using HyperEdge.Shared.Protocol;
using HyperEdge.Shared.Protocol.Models;
using HyperEdge.Shared.Services;
using HyperEdge.Backend.Db;
using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Services
{
    public class AccountService : ServiceBase<IAccountService>, IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _db;

        public AccountService(IMapper mapper, IDbContext db)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async UnaryResult<RegisterAccountResponse> RegisterAccount(RegisterAccountRequest req)
        {
            var accModel = new AccountModel();
            _mapper.Map(req, accModel);
            //
            var now = DateTime.Now;
            accModel.UpdatedAt = now;
            accModel.CreatedAt = now;
            //
            using (var tx = this._db.BeginTransaction())
            {
                await _db.Accounts.InsertAsync(accModel, tx);
                var defaultUserModel = new UserModel()
                {
                    AccountId = accModel.Id
                };
                //await _db.Users.InsertAsync(defaultUserModel, tx);
                tx.Commit();

                var accDto = _mapper.Map<AccountDTO>(accModel);
                return new RegisterAccountResponse() { Success = true, Account = accDto, UserId = defaultUserModel.Id };
            }
        }

        public async UnaryResult<UpdateAccountResponse> UpdateAccount(UpdateAccountRequest req)
        {
            var accModel = await _db.Accounts.FindAsync(x => x.Id == req.Id);
            _mapper.Map(req, accModel);
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hashBytes = hasher.ComputeHash(Encoding.ASCII.GetBytes(accModel.EKS));
                accModel.EKSHash = Convert.ToBase64String(hashBytes);
            }
            await _db.Accounts.UpdateAsync(accModel);
            return new UpdateAccountResponse() { Success = true };
        }
    }
}
