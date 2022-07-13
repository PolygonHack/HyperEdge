using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject(true)]
    public class GetChallengeResponse
    {
        public string Challenge { get; set; }
    }
}
