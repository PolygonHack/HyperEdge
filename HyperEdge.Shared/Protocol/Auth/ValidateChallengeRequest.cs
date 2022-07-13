using System;
using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class ValidateChallengeRequest
    {
        public Ulid UserId { get; set; }
        public string Signature { get; set; }
    }
}
