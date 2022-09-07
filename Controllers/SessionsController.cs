using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionController : Controller
{
    [HttpGet]
    public IActionResult GetNumber()
    {
        var count = Int32.Parse(HttpContext.Session.GetString("count") ?? "0" ) ;
        HttpContext.Session.SetString("count", (count += 1).ToString());

        return Ok(count);
    }

}