using Microsoft.AspNetCore.Mvc;

namespace Shelter.Api.Controllers;

public class HomeController : Controller
{
    [Route("/api/home")]
    public IActionResult Get()
    {
        var value = "Привіт Практика!";
        return Ok(value);
    }
}