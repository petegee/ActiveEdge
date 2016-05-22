namespace ActiveEdge.Infrastructure.Caching
{
    public interface ICacheableItem
    {
        int MinutesToCache { get; }

        string CacheKey { get; }
    }
}