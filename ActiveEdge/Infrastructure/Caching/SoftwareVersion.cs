namespace ActiveEdge.Infrastructure.Caching
{
    public static class SoftwareVersion
    {
        public static string Number(bool skipCache = false)
        {
            if (!skipCache)
            {
                var cachedSoftwareVersionItem = CacheHelper.Get<SoftwareVersionCacheItem>();

                if (cachedSoftwareVersionItem != null)
                {
                    return cachedSoftwareVersionItem.Number;
                }
            }

            var version = typeof(SoftwareVersion).Assembly.GetName().Version;

            var number = $"{version.Major}.{version.Minor}.{version.Build}";
            
            var softwareVersionItem = new SoftwareVersionCacheItem { Number = number };

            if (!skipCache)
            {
                CacheHelper.Cache(softwareVersionItem);
            }

            return softwareVersionItem.Number;
        }
    }
}