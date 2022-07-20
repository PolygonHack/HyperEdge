using MessagePack;
using System.Collections.Generic;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class UpdatePackageResponse
    {
        public PackageDTO Package { get; set; }
        public UpdatePackageResponse(PackageDTO package)
        {
            Package = package;
        }
    }
}
