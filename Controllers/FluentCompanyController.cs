using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetEntityFrameworkProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FluentCompanyController : ControllerBase
{
    private readonly FluentApiDbContext _db;
    private readonly FluentCompanyFactory _companyFactory;

    public FluentCompanyController(FluentApiDbContext db, FluentCompanyFactory companyFactory)
    {
        _db = db;
        _companyFactory = companyFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<CompanyFluent>> Index()
    {
        return await _db.FluentCompanies.ToListAsync();
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> Show(
        [FromRoute] Guid companyId
    ) {
        CompanyFluent? company = await _db.FluentCompanies
            .Include(c => c.Trainees)
            .FirstOrDefaultAsync(c => c.CompanyId == companyId);
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> Store(
        [FromBody] UpsertCompanyDto companyDto
    ) {
        CompanyFluent company = _companyFactory.Create(companyDto.Name);
        _db.FluentCompanies.Add(company);
        await _db.SaveChangesAsync();
        return Ok(company.CompanyId.ToString());
    }

    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid companyId
    ) {
        CompanyFluent? company = await _db.FluentCompanies.FindAsync(companyId);
        /* Note: dotnet is made to have these null checks.
         * trying to abstract request validation logic into DTO's with 
         * custom data annotations (which override the default 
         * ValidationResult function) requires more effort than 
         * benefits and additionally, won't remove the IDE warnings
         * that check for possible null values, since dotnet would not
         * track the validation done previously. */
        if (company == null) return NotFound();
        
        _db.FluentCompanies.Remove(company);
        await _db.SaveChangesAsync();
        return Ok("Company deleted");
    }

    [HttpPut("{companyId}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid companyId, 
        [FromBody] UpsertCompanyDto companyDto
    ) {
        CompanyFluent? company = await _db.FluentCompanies.FindAsync(companyId);
        if (company == null) return NotFound();

        company.Name = companyDto.Name;
        await _db.SaveChangesAsync();
        return Ok("Company updated");
    }
}
