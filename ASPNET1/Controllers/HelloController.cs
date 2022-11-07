using Microsoft.AspNetCore.Mvc;

namespace ASPNET1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController
{
    // https://localhost:7230/api/hello/greetings
    [HttpGet("greetings")]
    public string HelloWorld()
    {
        return "Hello World!";
    }

    [HttpGet("farewell")]
    public string ByeWorld()
    {
        return "Good Bye!";
    }
}
