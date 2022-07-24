using System;
using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetErc20TokensRequest
    {
        public Ulid OwnerId { get; set; }
        public uint Page { get; set; }
    }
}
