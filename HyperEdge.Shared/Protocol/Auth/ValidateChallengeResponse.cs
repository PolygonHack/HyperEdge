using System;
using MessagePack;


 namespace HyperEdge.Shared.Protocol
 {
    [MessagePackObject]
    public class ValidateChallengeResponse
    {
        [Key(0)]
        public string Token { get; set; }
        
        [Key(1)]
        public DateTimeOffset Expiration { get; set; }
        
        [Key(2)]
        public bool Success { get; set; }

        public static ValidateChallengeResponse Failed { get; } = new ValidateChallengeResponse() { Success = false };
        
        public ValidateChallengeResponse() {}

        public ValidateChallengeResponse(string token, DateTimeOffset expiration)
        {
            Success = true;
            Token = token;
            Expiration = expiration;
        }
    }
 }