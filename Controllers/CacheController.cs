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
        DateTime currentDate;
        var alarediyExist = _memoryCache.TryGetValue("DateTime", out currentDate);

        if (!alarediyExist || DateTime.UtcNow.Second - currentDate.Second > 30)
        {
            currentDate = DateTime.Now;
            var cacheEntryOption = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));

            _memoryCache.Set("DateTime", currentDate, cacheEntryOption);
        }
        return Ok(currentDate);
    }


}