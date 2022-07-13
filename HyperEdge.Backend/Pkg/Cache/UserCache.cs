using System;
using EasyCaching.Core;
using Microsoft.Extensions.Options;

using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Cache
{

public class UserCache
{
    private readonly IEasyCachingProviderFactory _cpFactory;    
    private readonly IEasyCachingProvider _cp;
    private readonly TimeSpan _expireTimeSpan;

    public UserCache(
        IOptions<UserCacheOptions> userCacheOptions,
        IEasyCachingProviderFactory cpFactory)
    {
        this._cpFactory = cpFactory ?? throw new ArgumentNullException(nameof(cpFactory));
        this._cp = cpFactory.GetCachingProvider("redis"); //FIXME
        this._expireTimeSpan = TimeSpan.Parse(userCacheOptions.Value.Expiration);
    }

    private static string MakeCacheKey(Ulid id) => $"users:{id.ToString()}";

    public async Task<(UserModel, bool)> GetAsync(Ulid id)
    {
        var cacheKey = UserCache.MakeCacheKey(id);
        var cacheValue = await this._cp.GetAsync<UserModel>(cacheKey);
        return (cacheValue.Value, cacheValue.HasValue);
    }

    public async Task SetAsync(UserModel userModel)
    {
        var cacheKey = UserCache.MakeCacheKey(userModel.Id);
        await this._cp.SetAsync<UserModel>(cacheKey, userModel, _expireTimeSpan);
    }

    public async Task RemoveAsync(UserModel userModel)
    {
        var cacheKey = UserCache.MakeCacheKey(userModel.Id);
        await this._cp.RemoveAsync(cacheKey);
    }
}

public class UserCacheOptions
{
    public string Expiration { get; set; }
}

}

