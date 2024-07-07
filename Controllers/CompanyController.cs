using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetEntityFrameworkProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly CompanyFactory _companyFactory;

    public CompanyController(AppDbContext db, CompanyFactory companyFactory)
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
    public async Task<IActionResult> Store(
        [FromBody] UpsertCompanyDto companyDto
    ) {
        Company company = _companyFactory.Create(companyDto.Name);
        _db.Companies.Add(company);
        await _db.SaveChangesAsync();
        return Ok(company.CompanyId.ToString());
    }

    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid companyId
    ) {
        Company? company = await _db.Companies.FindAsync(companyId);
        /* Note: dotnet is made to have these null checks.
         * trying to abstract request validation logic into DTO's with 
         * custom data annotations (which override the default 
         * ValidationResult function) requires more effort than 
         * benefits and additionally, won't remove the IDE warnings
         * that check for possible null values, since dotnet would not
         * track the validation done previously. */
        if (company == null) return NotFound();
        
        _db.Companies.Remove(company);
        await _db.SaveChangesAsync();
        return Ok("Company deleted");
    }

    [HttpPut("{companyId}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid companyId, 
        [FromBody] UpsertCompanyDto companyDto
    ) {
        Company? company = await _db.Companies.FindAsync(companyId);
        if (company == null) return NotFound();

        company.Name = companyDto.Name;
        await _db.SaveChangesAsync();
        return Ok("Company updated");
    }
}
