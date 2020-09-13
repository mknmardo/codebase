using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Cache
{
    public class MemCache<TEntity> : IMemCache<TEntity> where TEntity : class
    {
        private MemoryCache _memoryCache;

        public MemCache()
        {
            _memoryCache = MemoryCache.Default;
        }

        public List<TEntity> GetValue(string key)
        {
            return (List<TEntity>)_memoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset expiration)
        {
            return _memoryCache.Add(key, value, expiration);
        }

        public void Delete(string key)
        {
            if (_memoryCache.Contains(key))
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
