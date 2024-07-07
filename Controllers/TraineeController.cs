using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetEntityFrameworkProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraineeController : ControllerBase {

    private readonly AppDbContext _db;
    private readonly TraineeFactory _traineeFactory;

    public TraineeController(AppDbContext db, TraineeFactory traineeFactory) {
        _db = db;
        _traineeFactory = traineeFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<Trainee>> Index() {
        return await _db.Trainees.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Store(
        [FromBody] UpsertTraineeDto traineeDto
    ) {
        // Get and check parent model
        var company = await _db.Companies.FindAsync(traineeDto.CompanyId);
        if (company == null) return NotFound();
        // Perform database insertion
        var trainee = _traineeFactory.Create(traineeDto.Name, company);
        _db.Trainees.Add(trainee);
        await _db.SaveChangesAsync();
        // Success response
        return Ok(trainee.TraineeId.ToString());
    }
}