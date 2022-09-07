using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class CasheController : Controller
{
    [HttpGet]
    public IActionResult GetHour()
    {
        var count = Int32.Parse(HttpContext.Session.GetString("count") ?? "0");
        HttpContext.Session.SetString("count", (count += 1).ToString());
        
        return Ok(count);
    }

}