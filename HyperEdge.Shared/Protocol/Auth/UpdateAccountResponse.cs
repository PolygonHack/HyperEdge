using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject]
    public class UpdateAccountResponse
    {
        [Key(0)]
        public AccountDTO Account { get; set; }
        
        [Key(1)]
        public bool Success { get; set; }
    }
}
