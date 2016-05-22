namespace ActiveEdge.Infrastructure.Caching
{
    public class SoftwareVersionCacheItem : ICacheableItem
    {
        public SoftwareVersionCacheItem()
        {
            MinutesToCache = 60;
            CacheKey = "software_version_cache_key";
        }

        public int MinutesToCache { get; private set; }
        public string CacheKey { get; private set; }
        public string Number { get; set; }
    }
}