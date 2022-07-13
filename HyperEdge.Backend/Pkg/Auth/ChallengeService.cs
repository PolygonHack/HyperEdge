using System;
using EasyCaching.Core;
using System.Collections.Generic;
using System.Text;
using MessagePack;
using Microsoft.Extensions.Options;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;


namespace HyperEdge.Backend.Auth
{
    public class ChallengeService
    {
        private readonly IEasyCachingProviderFactory _cpFactory;
        private readonly EthereumMessageSigner _signer;
        private readonly ChallengeServiceOptions _opts;

        public ChallengeService(
            IOptions<ChallengeServiceOptions> opts,
            IEasyCachingProviderFactory cpFactory)
        {
            this._cpFactory = cpFactory;
            this._signer = new EthereumMessageSigner();
            this._opts = opts.Value;
        }

        public async Task<string> NewChallenge(Ulid userId, byte[] address)
        {
            var nonce = NonceGenerator.Get(_opts.NonceLength);
            var cp = _cpFactory.GetCachingProvider(_opts.CachingProvider);
            var expiresTimeSpan = TimeSpan.FromMinutes(1);
            var expires = DateTimeOffset.UtcNow.Add(expiresTimeSpan);
            var cacheKey = MakeCacheKey(userId.ToString());
            var challengeData = new ChallengeData
                {
                    Address = address.ToHex(),
                    Nonce = nonce,
                    Expiration = expires
                };
            await cp.SetAsync(cacheKey, challengeData, expiresTimeSpan);
            return nonce;
        }

        public async Task<bool> VerifyChallenge(Ulid userId, string signature)
        {
            var cacheKey = MakeCacheKey(userId.ToString());
            var cp = _cpFactory.GetCachingProvider(_opts.CachingProvider);
            var challenge = await cp.GetAsync<ChallengeData>(cacheKey);
            if (!challenge.HasValue)
            {
                return false;
            }
            var addressRec = _signer.HashAndEcRecover(challenge.Value.Nonce, signature);
            await cp.RemoveAsync(cacheKey);
            return addressRec == challenge.Value.Address;
        }

        private static string MakeCacheKey(string userId) => $"challenge:{userId}";
    }
}
