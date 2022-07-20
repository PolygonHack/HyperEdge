using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreateStoreRequest
    {
        public StoreDTO Store { get; set; }
        
        public CreateStoreRequest(StoreDTO model)
        {
            this.Store = model;
        }
    }
}
