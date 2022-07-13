using System;
using MessagePack;


namespace HyperEdge.Backend.Auth
{
    [MessagePackObject(true)]
    public class ChallengeData
    {
        public string Address { get; set; }
        public string Nonce { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}

