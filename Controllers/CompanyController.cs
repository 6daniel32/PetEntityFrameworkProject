using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetEntityFrameworkProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly ICompanyFactory _companyFactory;

    public CompanyController(AppDbContext db, ICompanyFactory companyFactory)
    {
        _db = db;
        _companyFactory = companyFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<Company>> Index()
    {
        return await _db.Companies.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Store([FromBody] UpsertCompanyDto companyDto)
    {
        Company company = _companyFactory.Create(companyDto.Name);
        _db.Companies.Add(company);
        await _db.SaveChangesAsync();
        return Ok(company.CompanyId.ToString());
    }

    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(Guid companyId) 
    {
        Company? company = await _db.Companies.FindAsync(companyId);
        if (company == null) return NotFound();
        
        _db.Companies.Remove(company);
        await _db.SaveChangesAsync();
        return Ok("Company deleted");
    }
}
