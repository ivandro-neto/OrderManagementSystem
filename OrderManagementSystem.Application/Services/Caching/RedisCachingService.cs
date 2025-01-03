using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace OrderManagementSystem.Application.Services.Caching;
public class RedisCachingService : IRedisCachingService
{
  private readonly IDistributedCache _cache;

  public RedisCachingService(IDistributedCache? cache)
  {
    _cache = cache;
  }

  public T? GetData<T>(string key){
    var data = _cache?.Get(key);

    if (data is null)
      return default(T);

    return JsonSerializer.Deserialize<T>(data);
  }
  public void SetData<T>(string key, T value)
  {
    var options = new DistributedCacheEntryOptions()
    {
      AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
    };

    _cache?.SetString(key, JsonSerializer.Serialize(value), options);
  }
}
