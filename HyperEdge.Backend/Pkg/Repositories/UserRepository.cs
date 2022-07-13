using System;
using EasyCaching.Core;
using MagicOnion.Server;

using HyperEdge.Backend.Cache;
using HyperEdge.Backend.Db;
using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Repositories
{

public partial class UserRepository : IUserRepository
{

    private readonly UserCache _userCache;
    private readonly IDbContext _db;
    private readonly IDbChangeSet _changes;

    public UserRepository(
        IDbContext db,
        UserCache userCache,
        IDbChangeSet changes)
    {
        this._db = db ?? throw new ArgumentNullException(nameof(db));
        this._userCache = userCache ?? throw new ArgumentNullException(nameof(userCache));
        this._changes = changes ?? throw new ArgumentNullException(nameof(changes)); 
    }

    public async Task<UserModel> GetAsync(Ulid id)
    {
        var (user, found) = await this._userCache.GetAsync(id);
        Console.WriteLine($"Fetching user:{id.ToString()} from cache: {found}");
        if (!found)
        {
            user = null; //await this.GetFromDbAsync(id);
            if (user is not null)
            {
                await this._userCache.SetAsync(user);
            }
        }
        return user;
    }

    public async Task CommitChanges()
    {
        await Task.Delay(1);
    }
}

}
