using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreateErc1155TokenResponse
    {
        public Erc1155TokenDTO Erc1155Token { get; set; }
        public CreateErc1155TokenResponse(Erc1155TokenDTO tm)
        {
            this.Erc1155Token = tm;
        }
    }
}
