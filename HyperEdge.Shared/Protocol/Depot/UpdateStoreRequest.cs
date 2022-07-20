using System;
using MessagePack;
using System.Collections.Generic;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class UpdateStoreRequest
    {
        public Ulid StoreId { get; set; }
    }
}
