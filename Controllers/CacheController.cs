using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Cookies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CacheCotroller : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    public CacheCotroller(IMemoryCache memoryCashe) => _memoryCache = memoryCashe;


    [HttpGet]
    public IActionResult Get()
    {
        var time = DateTime.Now.ToString("HH:mm:ss");
        var alarediyExist = _memoryCache.TryGetValue("DateTime", out time);

        if (!alarediyExist)
        {
            time = DateTime.Now.ToString("HH:mm:ss");
            var cacheEntryOption = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));

            _memoryCache.Set("DateTime", time, cacheEntryOption);
        }
        return Ok(time);
    }


}