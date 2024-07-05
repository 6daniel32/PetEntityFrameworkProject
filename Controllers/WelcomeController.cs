
using Microsoft.AspNetCore.Mvc;

public class CompanyController : Controller
{
    [HttpGet("/")]
    public string Index()
    {
        return "Hello world!";
    }
}