using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreateErc1155TokenResponse
    {
        public Erc1155TokenDTO Erc1155Token { get; set; }
    }
}
