using System;
using Grpc.Core;
using MagicOnion;


namespace HyperEdge.Backend.Errors
{
    public static class GeneralErrors
    {
        public static ReturnStatusException UserNotFound(Ulid Id)
        {
            return new ReturnStatusException(
                (Grpc.Core.StatusCode)1,
                $"User Id={Id.ToString()} not found");
        }
    }
}
