using System;
using System.Collections.Generic;
using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetErc1155TokensResponse
    {
        public List<Erc1155TokenDTO> Tokens;
    }
}
