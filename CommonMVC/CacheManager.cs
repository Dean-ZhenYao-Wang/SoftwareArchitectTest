using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.CommonMVC
{
    public class CacheManager
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        public T Get<T>(string key)
        {
            return (T)_cache[key];
        }

        /// <summary>
        /// Never expire
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="data">Cache objects</param>
        public void Set(string key, object data)
        {
            Set(key, data, 0);
        }

        /// <summary>
        /// Absolute expiration (current time expires after X minutes)
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="data">Cache objects</param>
        /// <param name="cacheTime">缓存时间</param>
        public void Set(string key, object data, int cacheTime)
        {
            Set(key, data, cacheTime, CacheExpiration.Absolute);
        }

        /// <summary>
        /// Set cache
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="data">Cache objects</param>
        /// <param name="cacheTime">Cache time</param>
        /// <param name="expiration">Cache type</param>
        public void Set(string key, object data, int cacheTime, CacheExpiration expiration)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();

            if (cacheTime > 0)
            {
                if (expiration == CacheExpiration.Absolute)
                {
                    policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
                }

                if (expiration == CacheExpiration.Sliding)
                {
                    policy.SlidingExpiration = TimeSpan.FromMinutes(cacheTime);
                }
            }

            _cache.Set(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Determine whether cached or not
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            return (_cache.Contains(key));
        }

        /// <summary>
        /// Remove cache entries
        /// </summary>
        /// <param name="key">Cache key</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// wipe cache
        /// </summary>
        public void Clear()
        {
            foreach (var item in _cache)
                Remove(item.Key);
        }
    }

    public enum CacheExpiration
    {
        /// <summary>
        /// Empty cache absolute expiration (current time expires after X minutes)
        /// </summary>
        Absolute,
        /// <summary>
        /// Relative expiration (expiration without access in X minutes)
        /// </summary>
        Sliding
    }

    /// <summary>
    /// Cache Manager Extension
    /// </summary>
    public static class CacheManagerExtentions
    {
        /// <summary>
        /// Get cache entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="manager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Callback Commission</param>
        /// <returns></returns>
        public static T Get<T>(this CacheManager manager, string key, Func<T> acquire)
        {
            return manager.Get(key, 0, acquire);
        }

        /// <summary>
        /// Get cache entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="manager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="cacheTime">0 Never expired</param>
        /// <param name="acquire">Callback Commission</param>
        /// <returns></returns>
        public static T Get<T>(this CacheManager manager, string key, int cacheTime, Func<T> acquire)
        {
            return manager.Get(key, cacheTime, CacheExpiration.Absolute, acquire);
        }

        /// <summary>
        /// Get cache entries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="manager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="cacheTime">Cache time</param>
        /// <param name="expiration">Expired type</param>
        /// <param name="acquire">Callback Commission</param>
        /// <returns></returns>
        public static T Get<T>(this CacheManager manager, string key, int cacheTime, CacheExpiration expiration, Func<T> acquire)
        {
            if (manager.IsSet(key))
            {
                return manager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (result != null)
                {
                    manager.Set(key, result, cacheTime, expiration);
                }
                return result;
            }
        }
    }
}
