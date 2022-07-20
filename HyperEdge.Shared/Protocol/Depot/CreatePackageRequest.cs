using MessagePack;
using System.Collections.Generic;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreatePackageRequest
    {
        public PackageDTO Package { get; set; }
        public CreatePackageRequest(PackageDTO package)
        {
            Package = package;
        }
    }
}
