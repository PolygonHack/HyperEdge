using System;
using MessagePack;

using HyperEdge.Shared.Protocol.Models;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]    
    public class RegisterAccountResponse
    {
        public AccountDTO Account { get; set; }        
        public bool Success { get; set; }
        public Ulid UserId { get; set; }
    }
}
