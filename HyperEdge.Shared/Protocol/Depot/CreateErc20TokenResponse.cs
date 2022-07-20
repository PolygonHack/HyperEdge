using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class CreateErc20TokenResponse
    {
        public Erc20TokenDTO Erc20Token { get; set; }
        public CreateErc20TokenResponse(Erc20TokenDTO tm)
        {
            this.Erc20Token = tm;
        }
    }
}
