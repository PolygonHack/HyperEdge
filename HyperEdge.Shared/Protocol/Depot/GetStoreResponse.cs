using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetStoreResponse
    {
        public StoreDTO Store { get; set; }
        
        public GetStoreResponse(StoreDTO model)
        {
            this.Store = model;
        }
    }
}
