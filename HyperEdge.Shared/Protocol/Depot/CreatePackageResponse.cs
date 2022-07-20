using MessagePack;
using System.Collections.Generic;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreatePackageResponse
    {
        public PackageDTO Package { get; set; }
        public CreatePackageResponse(PackageDTO package)
        {
            Package = package;
        }
    }
}
