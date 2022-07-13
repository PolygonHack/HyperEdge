using System.Data;
using MagicOnion;
using MagicOnion.Server;

using HyperEdge.Backend.Repositories;


namespace HyperEdge.Backend.Filters
{

public class FlushChangesAttribute : MagicOnionFilterAttribute
{
    public override async ValueTask Invoke(
        ServiceContext context,
        Func<ServiceContext, ValueTask> next)
    {
        var userRepo = context.ServiceProvider.GetService<IUserRepository>();
        await next(context);
        Console.WriteLine("Flushing changes to db...");
        userRepo.CommitChanges();
    }
}

}
