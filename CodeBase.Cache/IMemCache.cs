using System;
using System.Collections.Generic;

namespace CodeBase.Cache
{
    public interface IMemCache<TEntity> where TEntity : class
    {
        bool Add(string key, object value, DateTimeOffset expiration);
        void Delete(string key);
        List<TEntity> GetValue(string key);
    }
}