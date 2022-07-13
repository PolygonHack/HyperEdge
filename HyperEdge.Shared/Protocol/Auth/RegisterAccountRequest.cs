using System;
using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class RegisterAccountRequest
    {
        public byte[] Address { get; set; } = Array.Empty<byte>();
        public string DeviceUId { get; set; } = string.Empty;
    }
}
