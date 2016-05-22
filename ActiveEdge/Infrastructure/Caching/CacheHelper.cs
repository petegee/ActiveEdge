using System;
using System.Web;

namespace ActiveEdge.Infrastructure.Caching
{
    public static class CacheHelper
    {
        public static T Get<T>()
            where T : class, ICacheableItem, new()
        {
            if (HttpContext.Current == null || HttpContext.Current.Cache == null)
            {
                return null;
            }

            var tempCacheItem = new T();

            return (T)HttpContext.Current.Cache.Get(tempCacheItem.CacheKey);
        }
        
        public static void Cache<T>(T itemToCache)
            where T : class, ICacheableItem
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Cache != null)
            {
                HttpContext.Current.Cache.Add(itemToCache.CacheKey, itemToCache, null,
                    DateTime.UtcNow.AddMinutes(itemToCache.MinutesToCache), 
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.Default,
                    null);
            }
        }
    }
}