using System;

using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Services
{
    public interface ICurrentUserService
    {
        Task<UserModel> LoadAsync(Ulid userId);
        UserModel User { get; }
    }
}