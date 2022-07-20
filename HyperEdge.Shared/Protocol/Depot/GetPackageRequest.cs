using System;
using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetPackageRequest
    {
        public Ulid PackageId { get; set; }
    }
}
