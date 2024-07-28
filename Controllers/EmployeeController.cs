using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetEntityFrameworkProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase {

    private readonly AppDbContext _db;
    private readonly EmployeeFactory _employeeFactory;

    public EmployeeController(AppDbContext db, EmployeeFactory employeeFactory) {
        _db = db;
        _employeeFactory = employeeFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<Employee>> Index() {
        return await _db.Employees.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Store(
        [FromBody] UpsertEmployeeDto employeeDto
    ) {
        // Get and check parent model
        var company = await _db.Companies.FindAsync(employeeDto.CompanyId);
        if (company == null) return NotFound();
        // Perform database insertion
        var employee = _employeeFactory.Create(employeeDto.Name, company);
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        // Success response
        return Ok(employee.EmployeeId.ToString());
    }
}