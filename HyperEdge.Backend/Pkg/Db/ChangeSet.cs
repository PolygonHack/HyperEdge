using System;
using System.Collections.Generic;

using HyperEdge.Backend.Db.Models;


namespace HyperEdge.Backend.Db
{
    public class ChangeSet<TKey, T> where T : IModel<TKey>
    {
        public Dictionary<TKey, T> Added { get; set; } = new Dictionary<TKey, T>();
        public Dictionary<TKey, T> Updated { get; set; } = new Dictionary<TKey, T>();
        public Dictionary<TKey, T> Removed { get; set; } = new Dictionary<TKey, T>();

        public void Add(T model)
        {
            this.Added[model.Id] = model;
        }

        public void Update(T model)
        {
            this.Updated[model.Id] = model;
        }

        public void Remove(T model)
        {
            this.Removed[model.Id] = model;
        }
    }
}

