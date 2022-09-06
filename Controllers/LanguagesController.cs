using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class LanguagesController : Controller
{
    [HttpGet]
    public IActionResult GetLanguage()
    {
        var culture = HttpContext.Session.GetString("culture");

        if(string.IsNullOrWhiteSpace(culture))
            return NotFound();
        
        return Ok(culture);
    }

    [HttpPost]
    public IActionResult SetLanguage([FromQuery]string culture)
    {
        HttpContext.Session.SetString("culture", culture);

        return Accepted();
    }
}