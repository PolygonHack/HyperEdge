using Grpc.Core;
using System.Data;
using System.Security.Claims;
using MagicOnion;
using MagicOnion.Server;

using HyperEdge.Backend.Services;
using HyperEdge.Backend.Repositories;


namespace HyperEdge.Backend.Filters
{

public class LoadCurrentUserAttribute : MagicOnionFilterAttribute
{
    public override async ValueTask Invoke(
        ServiceContext context,
        Func<ServiceContext, ValueTask> next)
    {
        var userPrincipal = context.CallContext.GetHttpContext().User;
        var userId = userPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);
        Console.WriteLine($"JWT userId: {userId is null}");
        if (Ulid.TryParse(userId, out var currUserId))
        {
            var currUser = context.ServiceProvider.GetService<ICurrentUserService>();
            await currUser.LoadAsync(currUserId);
        }
        await next(context);
    }
}

}