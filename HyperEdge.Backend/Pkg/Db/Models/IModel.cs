using System;


namespace HyperEdge.Backend.Db.Models
{
    public interface IModel<TKey>
    {
        TKey Id { get; }
    }
}
