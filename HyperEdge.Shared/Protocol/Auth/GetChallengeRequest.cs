using System;
using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetChallengeRequest
    {
        public Ulid UserId { get; set; }
    }
}
