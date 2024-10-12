using System.Runtime.Caching;

MemoryCache cache = MemoryCache.Default;

string cacheKey = "myKey";
string cachedData = cache[cacheKey] as string;

if (cachedData == null)
{
    cachedData = "This is some data to cache!";
    CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };
    cache.Add(cacheKey, cachedData, policy);
    Console.WriteLine("Data added to cache.");
}
else
{
    Console.WriteLine("Data retrieved from cache: " + cachedData);
}


Console.ReadLine();