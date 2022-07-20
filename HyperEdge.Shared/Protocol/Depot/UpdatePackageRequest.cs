using System;
using MessagePack;
using System.Collections.Generic;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class UpdatePackageRequest
    {
        public Ulid PackageId { get; set; }
        public string Name { get; set; }
    }
}
