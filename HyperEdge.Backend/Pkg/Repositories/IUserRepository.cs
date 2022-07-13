using System;

using HyperEdge.Backend.Db;
using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Repositories
{

public partial interface IUserRepository
{
    Task<UserModel> GetAsync(Ulid id);
    Task CommitChanges();
}

}
