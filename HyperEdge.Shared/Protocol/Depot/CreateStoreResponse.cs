using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreateStoreResponse
    {
        public StoreDTO Store { get; set; }
        
        public CreateStoreResponse(StoreDTO model)
        {
            this.Store = model;
        }
    }
}

