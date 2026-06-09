using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var data = new[]
        {
            new { Id = 1, Name = "First Entry" },
            new { Id = 2, Name = "Second Entry" },
            new { Id = 3, Name = "Third Entry" }
        };

        return Ok(data);
    }
}