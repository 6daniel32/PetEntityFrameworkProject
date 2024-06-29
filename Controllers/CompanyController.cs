using Microsoft.AspNetCore.Mvc;

namespace PetEntityFrameworkProject.Controllers;
public class CompanyController : Controller
{
    private readonly AppDbContext _db;

    public CompanyController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("/testdb")]
    public async Task<string> Create() {
        Company company = new Company("Test Company");
        // Version for when adding the model to the context involves
        // costly I/O operations, such as a database query or a network 
        // request: await _db.Companies.AddAsync(company);
        _db.Companies.Add(company);
        await _db.SaveChangesAsync();
        return "Company created!";
    }
}
