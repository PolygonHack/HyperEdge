using MessagePack;


namespace HyperEdge.Shared.Protocol
{
    [MessagePackObject]
    public struct JoinChatRoomRequest
    {
        [Key(0)]
        public string RoomName { get; set; }

        [Key(1)]
        public string UserName { get; set; }
    }
}

