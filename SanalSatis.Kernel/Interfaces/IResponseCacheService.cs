using System;
using System.Threading.Tasks;

namespace SanalSatis.Kernel.Interfaces
{
    public interface IResponseCacheService
    {
         Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTolive);
         Task<string> GetCachedResponseAsync(string cacheKey);
    }
}