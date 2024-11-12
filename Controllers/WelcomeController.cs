
using Microsoft.AspNetCore.Mvc;

public class WelcomeController : Controller
{
    [HttpGet("/")]
    public string Index()
    {
        return "Hi world!";
    }
}